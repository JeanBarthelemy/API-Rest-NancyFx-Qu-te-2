using System;
using System.Collections.Generic;
using System.Text;

namespace API_Rest_Nancy_Quête_2
{
    class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string name, string password)
        {
            UserName = name;
            Password = password;
        }

        public User()
        { }
    }
}
