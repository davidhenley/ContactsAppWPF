using System.IO;
using System.Windows;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "contacts.db");
    }
}
