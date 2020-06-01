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
using Octokit;

namespace CompareRepo
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<string> strings { get; set; } = new List<string>();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            searchReposit_GitHub(githubLink_Author.Text, githubLink_ProjectName.Text, githubLink_Path.Text);
        }

        public async void searchReposit_GitHub(string author,string projectName, string path)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
                
                var contents = await client
                                    .Repository
                                    .Content
                                    .GetAllContents(author, projectName, path);

                foreach (var item in contents)
                {
                    var result = item.Content;
                    strings.Add(result);
                    repoFileContent.Text = result;
                }

                foreach (var item in strings)
                {
                    //MessageBox.Show(item);
                    var words = item.Split(' ');
                    MessageBox.Show(words.Count().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
