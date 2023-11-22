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
using System.IO;
using Microsoft.Win32;
using System.Threading.Tasks.Dataflow;

namespace WpfAppTarsas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ossvenyek> listaOsvenyek = new List<Ossvenyek> ();
        string megnyitottFajl = "";
        public MainWindow()
        {
            InitializeComponent();
            //TextBoxBeToltes();

        }
        private void TextBoxBeToltes()
        {


            for (int i = 0; i < listaOsvenyek.Count; i++)
            {
                //CheckBox cbGomb = new CheckBox();
                //cbGomb.Name = $"cbGomb{i}";
                //StackPanel spTarolo = new StackPanel();
                //spTarolo.Orientation = Orientation.Horizontal;
                TextBox tbMezo = new TextBox();
                tbMezo.Text = listaOsvenyek[i].Mezok;
                tbMezo.IsReadOnly = true;
                tbMezo.CharacterCasing = CharacterCasing.Upper;
                tbMezo.MouseDoubleClick += (s, e) =>
                {
                    if (s is TextBox)
                    {
                        var textBox = s as TextBox;
                        textBox.IsReadOnly = false;
                    }
                    else
                        MessageBox.Show("");
                };
                tbMezo.KeyDown += (s, e) =>
                {
                    if (e.Key == Key.M)
                        e.Handled = false;
                    else if (e.Key == Key.V)
                        e.Handled = false;
                    else if (e.Key == Key.E)
                        e.Handled = false;
                    else if (e.Key == Key.Space)
                        e.Handled = true;
                    else
                        e.Handled = true;
                };
                //spTarolo.Children.Add(cbGomb);
                //spTarolo.Children.Add(tbMezo);
                lbSzerkeszto.Items.Add(tbMezo);
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter mentes = new StreamWriter(megnyitottFajl);
            foreach (var elem in lbSzerkeszto.Items)
                mentes.WriteLine(elem.ToString().Split(' ')[1]);
            mentes.Close();
            MessageBox.Show("Ügyi vagy:)");
        }

        private void btnMentesMaskent_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "Szöveges fájl (*.txt) | *.txt ";
            sfd.Title = "Adja meg a mentés nevét!";
            if (sfd.ShowDialog() == true)
            {

                StreamWriter mentes = new StreamWriter(sfd.FileName);
                foreach (var elem in lbSzerkeszto.Items)
                    mentes.WriteLine(elem.ToString().Split(' ')[1]);

                mentes.Close();
                MessageBox.Show("Ügyi vagy:)");

            }
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            lbSzerkeszto.Items.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                listaOsvenyek = File.ReadAllLines(ofd.FileName).Select(x => new Ossvenyek(x)).ToList();
                MessageBox.Show("Betöltés sikeres!");
            }
            TextBoxBeToltes();
            megnyitottFajl = ofd.FileName;

        }

        private void btnUjOsveny_Click(object sender, RoutedEventArgs e)
        {
            TextBox ujUres = new TextBox();
            //StackPanel spTarolo = new StackPanel();
            //CheckBox cbGomb = new CheckBox();
            //cbGomb.Name = $"cbGomb{lbSzerkeszto.Items.Count}";
            ujUres.KeyDown += (s, e) =>
            {
                if (e.Key == Key.M)
                {
                    e.Handled = false;
                    ujUres.Width += 20;

                }
                else if (e.Key == Key.V)
                {
                    e.Handled = false;
                    ujUres.Width += 20;
                }
                else if (e.Key == Key.E)
                {
                    e.Handled = false;

                }
                //else if (e.Key == Key.Space)
                //    e.Handled = true;
                else
                    e.Handled = true;
            };
            ujUres.CharacterCasing = CharacterCasing.Upper;
            ujUres.Width = 100;
            //spTarolo.Children.Add(cbGomb);
            //spTarolo.Children.Add(ujUres);
            //spTarolo.Orientation = Orientation.Horizontal;
            lbSzerkeszto.Items.Add(ujUres);
            lbSzerkeszto.Items.MoveCurrentToLast();
            lbSzerkeszto.ScrollIntoView(lbSzerkeszto.Items.CurrentItem);
        }

        

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            //foreach (StackPanel item in lbSzerkeszto.Items)
            //{
            //    foreach (CheckBox cbGombok in item.Children)
            //    {
            //        if (cbGombok.IsChecked == true)
            //        {
            //            lbSzerkeszto.Items.Remove(cbGombok);
            //        }
            //    }
            //}
        }
    }
}
