using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDocker.Domain.Dtos.Common
{
    public class LoginRequest
    {
        public string userName { set; get; }

        public string passWord { set; get; }

        public LoginRequest( string username, string password)
        {
            username = userName;
            password = passWord;
        }
    }
}
