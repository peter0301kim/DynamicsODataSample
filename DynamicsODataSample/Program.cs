using NAV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsODataSample
{
    class Program
    {
        static void Main(string[] args)
        {

            Uri uri = new Uri("http://dynamicsnavdemo:7048/BC/ODataV4/Company('CRONUS%20International%20Ltd.')");

            NAV.NAV nav = new NAV.NAV(uri);

            var serviceCreds = new NetworkCredential("Administrator", "Noafl2020");
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", serviceCreds);
            nav.Credentials = cache;


            PrintPurchaseInvoice(nav);
            PrintAccounts(nav);
            PrintCustomers(nav);
            PrintVendors(nav);

            PrintGLCode(nav);

            
            PrintJobList(nav);

            Console.Read();
        }

        private static void PrintPurchaseInvoice(NAV.NAV nav)
        {
            Console.WriteLine($"------------- PurchaseInfoice ---------------");
            //Cust_LedgerEntries
            int i = 0;
            foreach (var v in nav.PurchaseInvoice)
            {
                Console.WriteLine($"No.:{v.No}, Entry_Point:{v.Entry_Point}, Purchaser_Code:{v.Purchaser_Code}");
                i++;
            }

            Console.ReadLine();
        }
        private static void PrintCustomers(NAV.NAV nav)
        {
            Console.WriteLine($"------------- Customers ---------------");
            //Cust_LedgerEntries
            int i = 0;
            foreach (var v in nav.Customers)
            {
                Console.WriteLine($"No.:{v.No}, Name:{v.Name}, Contact:{v.Contact}");
                i++;
            }

            Console.ReadLine();
        }
        private static void PrintAccounts(NAV.NAV nav)
        {
            Console.WriteLine($"------------- GLAccountList ---------------");

            int i = 0;
            foreach (var v in nav.GLAccountList)
            {
                Console.WriteLine($"index:{i}, No:{v.No}, Name:{v.Name}");
                i++;
            }

            Console.ReadLine();
        }

        private static void PrintVendors(NAV.NAV nav)
        {
            Console.WriteLine($"------------- Vendors ---------------");

            int i = 0;
            foreach (var v in nav.Vendors)
            {
                Console.WriteLine($"index:{i}, No:{v.No}, Name:{v.Name}");
                i++;
            }

            Console.ReadLine();
        }


        private static void PrintGLCode(NAV.NAV nav)
        {

            bool glFound = false;
            foreach (NAV.G_LEntries gl in nav.G_LEntries)
            {
                glFound = true;
                Console.WriteLine($"GL Code.:{gl.G_L_Account_No}, Name:{gl.G_L_Account_Name}");
            }

            if (!glFound)
            {
                Console.WriteLine("There are no GL Code");
            }
            Console.ReadLine();

        }




        private static void PrintJobList(NAV.NAV nav)
        {
            var jobList = from c in nav.Job_List
                            select c;

            bool jobFound = false;
            foreach (NAV.Job_List j in nav.Job_List)
            {
                jobFound = true;
                Console.WriteLine($"Job No.: {j.No},Job Name: {j.Description}");
            }

            if (!jobFound)
            {
                Console.WriteLine("There are no Job");
            }
            Console.ReadLine();
        }


        private static void PrintVendor(NAV.NAV nav)
        {
            var vendors = from c in nav.VendorLedgerEntries
                          //where c.Vendor_Name.StartsWith("Paytec")
                          select c;

            Boolean vendorFound = false;
            foreach (var v in vendors)
            {
                vendorFound = true;
                Console.WriteLine($"Vendor No.:{v.Vendor_No}, Vendor Name:{v.Vendor_Name}");
            }

            if (!vendorFound)
            {
                Console.WriteLine("There are no Job");
            }
            Console.ReadLine();
        }

    }
}
