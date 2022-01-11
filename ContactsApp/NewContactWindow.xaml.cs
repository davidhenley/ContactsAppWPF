using ContactsApp.Models;
using SQLite;
using System.IO;
using System.Windows;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save contact
            var contact = new Contact
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            using var conn = new SQLiteConnection(App.dbPath);
            conn.CreateTable<Contact>();
            conn.Insert(contact);

            this.Close();
        }
    }
}
