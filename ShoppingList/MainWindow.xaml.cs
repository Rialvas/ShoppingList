using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBTN_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ItemTBX.Text))
            {
                if (!ListLBX.Items.Contains(ItemTBX.Text))
                {
                    ListLBX.Items.Add(ItemTBX.Text);
                }
            }
            ItemTBX.Clear();
        }

        private void DeleteBTN_Click_1(object sender, RoutedEventArgs e)
        {
            ListLBX.Items.Remove(ListLBX.SelectedItem);
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            string saveFile = $"{FilePathTBX.Text}.txt";
            if (!System.IO.File.Exists(System.IO.Path.Combine(docPath, saveFile)))
            {
                using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, saveFile)))
                {
                    foreach (string item in ListLBX.Items)
                    {
                        outputFile.WriteLine(item);
                    }
                    MessageBox.Show("Shopping list saved.");
                }
            }
            // if file found, send error message
            else
            {
                MessageBox.Show("Shopping list under that name exists.");
            }
        }

        private void LoadBTN_Click(object sender, RoutedEventArgs e)
        {
            string saveFile = $"{FilePathTBX.Text}.txt";
            if (System.IO.File.Exists(System.IO.Path.Combine(docPath, saveFile)))
            {
                ListLBX.Items.Clear();
                using (StreamReader inputFile = new StreamReader(System.IO.Path.Combine(docPath, saveFile)))
                {
                    string line = "";
                    {
                        while ((line = inputFile.ReadLine()) != null)
                        {
                            ListLBX.Items.Add(line);
                        }
                        MessageBox.Show("Shopping list loaded.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Unable to find list");
            }
        }

        private void NewListBTN_Click(object sender, RoutedEventArgs e)
        {
            ListLBX.Items.Clear();
        }
    }
}