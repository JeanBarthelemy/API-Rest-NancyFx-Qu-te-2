using System;
using Nancy.Hosting.Self;
using Nancy;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Linq;
using System.Net.Http;

namespace API_Rest_Nancy_Quête_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseTestSet.DatabaseSetter();

            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
            }
        }
    }

    public class UserModule : NancyModule
    {
        public UserModule()
        {
            Get("/users/{UserId}", parameters => ReturnUserData(parameters.UserId)); ;        
            Get("/users/{UserId}/delete", parameters => DeleteUser(parameters.UserId));
            Get("/users/{UserName}/{Password}", parameters => PutNewUser(parameters.UserName, parameters.Password));
            Get("/authentify/{UserName}/{Password}", parameters => AuthentifyUser(parameters.UserName, parameters.Password));       
        }

        public string ReturnUserData(int userId)
        {
            using (var context = new DataContext())
            {
                var userFromDB = (from u in context.Users
                                  where u.UserId == userId
                                  select u).FirstOrDefault();
                
                String jsonUser = JsonConvert.SerializeObject(userFromDB);
                return jsonUser;
            }
        }

        public string DeleteUser(int userId)
        {
            using (var context = new DataContext())
            {
                var userFromDB = (from u in context.Users
                                  where u.UserId == userId
                                  select u).FirstOrDefault();
                context.Remove(userFromDB);
                context.SaveChanges();
                string deleted = "The user has been deleted";
                return deleted;
            }
        }

        public string PutNewUser(string name, string password)
        {
            using (var context = new DataContext())
            {
                User newUser = new User() { UserName = name, Password = password};
                context.Add(newUser);
                context.SaveChanges();
                String jsonNewUser = JsonConvert.SerializeObject(newUser);

                string put = "The following user is added";
                return put + "\n" + jsonNewUser;
            }
        }

        public string AuthentifyUser(string name, string password)
        {
            using (var context = new DataContext())
            {
                var getNameAndPassword = from u in context.Users
                                         where name == u.UserName && password == u.Password
                                         select new { u.UserName, u.Password };
                var user = from u in context.Users
                           where name == u.UserName && password == u.Password
                           select u;

                String jsonUserAuthentified = JsonConvert.SerializeObject(user);

                if (getNameAndPassword.Count() == 1)
                {
                    string authentified = "Authentification succeded";
                    return authentified + "\n" + jsonUserAuthentified;
                }
                else
                {
                    string notAuthentified = "Authentification failed : the password was not corresponding to the user or the user doesn't exist";
                    return notAuthentified;
                }
            }
        }
    }
}
