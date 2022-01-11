using ContactsApp.Models;
using SQLite;
using System.IO;
using System.Windows;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class DetailsContactWindow : Window
    {
        public Contact Contact { get; }
        public DetailsContactWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;

            Contact = contact;

            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Contact.Name = nameTextBox.Text;
            Contact.Email = emailTextBox.Text;
            Contact.Phone = phoneTextBox.Text;

            using var conn = new SQLiteConnection(App.dbPath);
            conn.CreateTable<Contact>();
            conn.Update(Contact);

            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using var conn = new SQLiteConnection(App.dbPath);
            conn.CreateTable<Contact>();
            conn.Delete(Contact);

            this.Close();
        }
    }
}
