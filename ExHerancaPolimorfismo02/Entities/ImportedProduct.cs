
using System.Globalization;
using System.Text;

namespace ExHerancaPolimorfismo02.Entities
{
    internal class ImportedProduct : Product
    {
        public  double CustomsFee { get; set; }

        public ImportedProduct() { 
        }

        public ImportedProduct(string name, double price, double customsFee)
            : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public override string PriceTag()
        {  
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" $ ");
            sb.Append(TotalPrice().ToString("F2", CultureInfo.InvariantCulture));
            sb.Append(" (Customs fee: $ ");
            sb.Append(CustomsFee);
            sb.Append(")");

            return sb.ToString();
        }

        public double TotalPrice()
        {
            return Price + CustomsFee;
        }
    }
}
