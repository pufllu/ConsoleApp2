using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ConsoleApp2
{
    class Program
    {     
        static void Main(string[] args)
        {
            List<User> userList = new List<User>();
            string[] lines = File.ReadAllLines(@"C:\Users\Данил\source\repos\ConsoleApp2\ConsoleApp2\bin\Debug\user.txt");
            int i = lines.Count();
            string[] vs = new string[i];
            string Login;
            string Password;

            foreach (var line in lines)
            {
                User user = new User();
                vs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Login = vs[0];
                Password = vs[1];
                user.Login = Login;
                user.Password = Password;
                userList.Add(user);
            }

            StreamWriter sw = new StreamWriter(@"C:\Users\Данил\source\repos\ConsoleApp2\ConsoleApp2\bin\Debug\user2.txt", false);
           
            using (var context = new MyDbContext())
            {
                var oldlist = context.Users.Select(x => new { x.Login, x.Password }).ToList();
                foreach (var text in oldlist)
                {
                    sw.WriteLine(text);
                }
                sw.Close();
                foreach (var item in userList)
                {
                    context.Users.Add(item);
                    context.SaveChanges();
                }
            }
            
        }   
    }
}
