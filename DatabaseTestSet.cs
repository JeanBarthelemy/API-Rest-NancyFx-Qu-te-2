using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace API_Rest_Nancy_Quête_2
{
    class DatabaseTestSet
    {
        public static void DatabaseSetter()
        {
            using (var context = new DataContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var user1 = new User()
                {
                    UserName = "Jean",
                    Password = "1234"
                };
                var user2 = new User()
                {
                    UserName = "Melanie",
                    Password = "2345"
                };
                var user3 = new User()
                {
                    UserName = "Charlie",
                    Password = "3456"
                };
                var user4 = new User()
                {
                    UserName = "Angelo",
                    Password = "4567"
                };
                var user5 = new User()
                {
                    UserName = "Dimitri",
                    Password = "5678"
                };
                var user6 = new User()
                {
                    UserName = "Alban",
                    Password = "6789"
                };
                var user7 = new User()
                {
                    UserName = "Margot",
                    Password = "7891"
                };
                var user8 = new User()
                {
                    UserName = "Lucie",
                    Password = "8910"
                };
                var user9 = new User()
                {
                    UserName = "Eric",
                    Password = "9101"
                };
                var user10 = new User()
                {
                    UserName = "Isabelle",
                    Password = "1011"
                };

                List<User> manyUser = new List<User>();
                manyUser.Add(user1);
                manyUser.Add(user2);
                manyUser.Add(user3);
                manyUser.Add(user4);
                manyUser.Add(user5);
                manyUser.Add(user6);
                manyUser.Add(user7);
                manyUser.Add(user8);
                manyUser.Add(user9);
                manyUser.Add(user10);

                context.AddRange(manyUser);
                context.SaveChanges();
            }
        }
    }
}
