using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace GloboClima.API.Services
{
    public class HelperService
    {
        public enum View
        {
            Admin, // CAN SEE RECORDS
            
            User // CAN ONLY SEE RECORDS THAT ARE INVOLVED WITH
        }

        public string Encripta(string texto)
        {
            String retorno = "";
            String stexto = texto;
            if (stexto == "")
            {
                return stexto;
            }
            while (true)
            {
                String letra = stexto.Substring(0, 1);
                int nnumero = char.ConvertToUtf32(letra, 0);
                nnumero += 166;
                string snumero = nnumero.ToString();
                if (snumero.Length < 3)
                {
                    snumero = "0" + snumero;
                }
                if (snumero.Length < 3)
                {
                    snumero = "0" + snumero;
                }
                retorno += snumero;
                stexto = stexto.Substring(1);
                if (stexto == "")
                {
                    break;
                }
            }

            return retorno;
        }

        public string HashMd5(string text)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

       

        

        public string GetUsernameFromEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }

            int atIndex = email.IndexOf('@');
            if (atIndex > 0)
            {
                return email.Substring(0, atIndex);
            }
            else
            {
                return email;
            }
        }
    }


}