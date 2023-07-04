using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT_Auth_Demo.Helpers
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY4ODQ0MjcyMSwiaWF0IjoxNjg4NDQyNzIxfQ.6Tyz0dSGtzy9-WkqjUjVTivl_mwB3Hc1xXeS9ss0N84";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken()
        {
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            DateTime Expiry = DateTime.UtcNow.AddMinutes(1);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload
            {
                {"sub", "testSubject" },
                {"Name", "Scott" },
                {"email", "smithtest@test.com" },
                {"exp", ts },
                {"iss", "http://localhost:5237" }, //Issuer - the party generating the JWT
                {"aud", "http://localhost:5237" }  // Audience - the address of the resource
            };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(secToken);

            Console.WriteLine( tokenString );
            Console.WriteLine( "Consume Token" );

            return tokenString;
        }
    }
}
