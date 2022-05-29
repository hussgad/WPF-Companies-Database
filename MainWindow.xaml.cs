using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFBind_14;
using System.Xml.Serialization;

namespace WPFDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Company> companies;
        Company currentCompany;
        XmlSerializer serializer;
        System.IO.FileStream fileStream;

        public MainWindow()
        {
            InitializeComponent();
            companies = new List<Company>();
            serializer = new XmlSerializer(typeof(List<Company>));
            fileStream = new System.IO.FileStream("Companies.xml", System.IO.FileMode.Open);
            companies = (List<Company>)serializer.Deserialize(fileStream);
            currentCompany = companies.FirstOrDefault();

            CompaniesList.DataContext = companies;
        }

        private void CompaniesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentCompany = CompaniesList.SelectedItem as Company;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string count = DescriptionTextBox.Text.Length.ToString();
            CharactersLeftLabel.Content = count;
        }
    }
}
