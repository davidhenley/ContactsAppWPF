using ContactsApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Contact> Contacts { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();

            ReadDatabase();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var newContactWindow = new NewContactWindow { Owner = this };
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        private void ReadDatabase()
        {
            using var conn = new SQLiteConnection(App.dbPath);
            conn.CreateTable<Contact>();
            Contacts = (conn.Table<Contact>().ToList()).OrderBy(x => x.Name).ToList();

            contactsListView.ItemsSource = Contacts;
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBoxText = (sender as TextBox)?.Text;
            var filteredContacts = Contacts
                .Where(x => x.Name.Contains(textBoxText, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            contactsListView.ItemsSource = filteredContacts;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contactsListView.SelectedItem is null) return;

            var detailContactWindow = new DetailsContactWindow((Contact)contactsListView.SelectedItem) { Owner = this };
            detailContactWindow.ShowDialog();

            ReadDatabase();
        }
    }
}

