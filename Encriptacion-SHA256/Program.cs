using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encriptacion_SHA256
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Models.EncriptacionEntities db=new Models.EncriptacionEntities())
            {
                //Models.user oUser = new Models.user();
                //oUser.username = "Erick";
                //oUser.pass = Encrypt.GetSHA256("123456");
                //db.user.Add(oUser);
                //db.SaveChanges();

                //Models.user oUser = new Models.user();
                //oUser.username = "Marco";
                //oUser.pass = Encrypt.GetSHA256("0987654321");
                //db.user.Add(oUser);
                //db.SaveChanges();

                string username = "Marco";
                string pass = "0987654321";
                string ePass = Encrypt.GetSHA256(pass);

                var oUser = (from d in db.user
                             where d.username == username && d.pass == ePass
                             select d).FirstOrDefault();
                if (oUser != null)
                {
                    Console.WriteLine("..........::::::::::Si existe su Usuario: " + username + " en la Base de Datos::::::::::.......... \n\n" 
                                    + "..........::::::::::Presione una tecla para salir::::::::::..........");
                    Console.ReadKey();
                }                     
                else
                    Console.WriteLine("..........::::::::::Datos invalidos, Usuario: " + username + ", Contraseña: " + pass + ", vuelva a intentar::::::::::.......... \n\n" 
                                    + "..........::::::::::Presione una tecla para salir::::::::::..........");
                    Console.ReadKey();
                          
            }
        }
    }
}
