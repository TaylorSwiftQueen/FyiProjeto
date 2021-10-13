using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFyiT3
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionFactory.GetCrmService();
            Console.WriteLine("Qual oportunidade você deseja aplicar o desconto ?");
            string Id = Console.ReadLine();
            
            Update update = new Update(service);
            
            EntityCollection parentsid = update.RetrieveParentId(new Guid(Id),Id);

            foreach (Entity parentid in parentsid.Entities)
            {
                string NivelDoCliente = parentid["g07_niveldocliente"].ToString();
                Console.WriteLine(parentid["g07_niveldocliente"].ToString());
                EntityCollection nivels = update.RetrieveNivelDoCliente(new Guid("e2e013c9-cd27-ec11-b6e6-002248372ef6"),NivelDoCliente);
               
                foreach (Entity nivel in nivels.Entities)
                {


                    Console.WriteLine(nivel["g07_valordedesconto"].ToString());

                    Console.WriteLine("Voce deseja atualizar essa oportunidade?");

                    char S = char.Parse(Console.ReadLine());

                    if (S == 's')
                    {
                        Console.WriteLine("Qual o novo valor de desconto?");
                        string desc = Console.ReadLine();
                        update.UpdateDesc(desc);
                    }

                    else
                    {
                        Console.WriteLine("Obrigado!!");
                    }
                }
            }

            
            
            






        }
    }
}
