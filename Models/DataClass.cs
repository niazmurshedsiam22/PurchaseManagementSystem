using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseManagementSystem.Models
{
    public class DataClass
    {
        private readonly ConnectionStringClass connectionStringClass;
        public DataClass(ConnectionStringClass cc)
        {
            connectionStringClass = cc;
        }
        public IList<Item> Items;

        public IList<Purchase> purchases;

        public IList<Issuance> issuances;

        public IList<Item> getItemsData(string Data)
        {
            if (Data == null)
            {
                Items = connectionStringClass.items.ToList();
            }
            Items = connectionStringClass.items.Where(x => x.item_status == Data).ToList();
            return Items;
        }

        public IList<Purchase> getPurchasesData(string Data)
        {
            if(Data == null)
            {
                purchases = connectionStringClass.purchases.ToList();
            }
            purchases = connectionStringClass.purchases.Where(x => x.vendor == Data).ToList();
            return purchases;
            
        }

        public IList<Issuance> getIssuancesData(string Data)
        {
            if (Data == null)
            {
                issuances = connectionStringClass.issuances.ToList();
            }
            issuances = connectionStringClass.issuances.Where(x => x.emp_name == Data).ToList();
            
            return issuances;
        }

    }
}
