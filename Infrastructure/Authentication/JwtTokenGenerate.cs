﻿using System.IdentityModel.Tokens.Jwt;
using Application.Common.Interfaces.Authentication;
using System.Security.Claims;
using System.Text;
using Application.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Infrastructure.Authentication;

public class JwtTokenGenerate(
    IDateTimeProvider dateTimeProvider,
    IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerate
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;
    
    public string GenerateToken(Guid id, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SigningKey)),
            SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            claims: claims,
            signingCredentials: signingCredentials);
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}