using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace ProjetoFyiT3
{
    public class Update
    {
        

        public IOrganizationService Service { get; set; }

        public Update(IOrganizationService service)
        {
            this.Service = service;
        }


        public EntityCollection RetrieveParentId(Guid parentId,string id)
        {
            QueryExpression queryOpportunity = new QueryExpression("opportunity");
            queryOpportunity.ColumnSet.AddColumns("g07_niveldocliente");
            queryOpportunity.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, id);
            
            return this.Service.RetrieveMultiple(queryOpportunity);
        }

        public EntityCollection RetrieveNivelDoCliente(Guid parentId,string desc)
        {
            QueryExpression queryNivelDoCliente = new QueryExpression("g07_niveldocliente");
            queryNivelDoCliente.ColumnSet.AddColumns("g07_valordedesconto");
            queryNivelDoCliente.Criteria.AddCondition("g07_niveldocliente", ConditionOperator.Equal, desc);

            return this.Service.RetrieveMultiple(queryNivelDoCliente);
        }

        public void UpdateDesc(string desc)
        {
            Entity nivel = new Entity("g07_niveldocliente");
            nivel.Id = new Guid("e2e013c9-cd27-ec11-b6e6-002248372ef6");
            nivel["g07_discountamount"] = desc;
            this.Service.Update(nivel);
        }
    }
}
