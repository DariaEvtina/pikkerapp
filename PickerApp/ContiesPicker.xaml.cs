using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContiesPicker : ContentPage
    {
        Picker picker;
        Picker picker2;
        Image mk;
        StackLayout st;
        StackLayout st1;
        WebView wv;
        Button more;
        Label lbl;
        string[] txt = new string[] { "Ida-Viru maakonnas on kaheksa omavalitsusüksust: neli linna ja neli valda.", "Reljeefilt on Jõgevamaale iseloomulikud piklikud künkad (voored) ja orud, mille kujundasid jääaegsed liustikud.", "Reljeefilt on Jõgevamaale iseloomulikud piklikud künkad (voored) ja orud, mille kujundasid jääaegsed liustikud.", "Lääne-Virumaa kõrgeim tipp on Emumägi (166 m), pikim jõgi Kunda jõgi (69 km) ja suurim järv on Porkuni järv (41,5 ha).", "Põlva maakond ehk Põlvamaa 1. järgu haldusüksus Eestis. Hõlmab suurema osa endise Põlva rajooni ", "Pärnumaa infoväravast leiad kõik olulise, mida vajad Pärnumaal elamiseks, õppimiseks ja töötamiseks - kinnisvara pakkumised, töökohad, koolid ja palju muud.", "Rapla maakond ehk Raplamaa on 1. järgu haldusüksus Eestis. Raplamaa piirneb põhjas Harju, idas Järva, lõunas Pärnu, läänes Lääne maakonnaga", "Saaremaa on Eesti suurim saar ning Sjællandi, Ojamaa ja Fyni järel pindalalt neljas saar Läänemeres.", "Tartu maakond ehk Tartumaa on 1. järgu haldusüksus Eestis.", "Harju maakond ehk Harjumaa on 1. järgu haldusüksus Põhja-Eestis.", "Hiiumaa on Eesti suuruselt teine saar, Lääne-Eesti saarestiku põhjapoolseim saar.", "Maakond asub Eesti keskosas ning piirneb läänes Harju ja Rapla, põhjas ja kirdes Lääne-Viru, kagus Jõgeva, lõunas Viljandi ning edelas Pärnu maakonnaga", "Võru maakond ehk Võrumaa on 1. järgu haldusüksus Eesti kaguosas", "Viljandi maakond ehk Viljandimaa on maakond Eesti lõunaosas. ", "Valga maakond ehk Valgamaa on 1. järgu haldusüksus Eestis. Hõlmab enamiku Valga rajooni alast." };
        string[] conties = new string[] { "IDA-VIRUMAA", "JÕGEVAMAA", "LÄÄNEMAA", "LÄÄNE-VIRUMAA", "PÕLVAMAA", "PÄRNUMAA", "RAPLAMAA", "SAAREMAA", "TARTUMAA", "HARJUMAA", "HIIUMAA", "JÄRVAMAA", "VÕRUMAA", "VILJANDIMAA", "VALGAMAA" }; 
        string[] cities = new string[] { "Johvi", " Jõgeva", "Haapsalu", "Rakvere", "Polva", "Pärnu", "Rapla", "Kuressaare", "Tartu", "Tallinn", "Kärdla", "Paide", "Võru", "Viljandi", "Valga" };
        string[] conties_URLs = new string[] { "https://idaviru.ee/", "https://visitjogeva.com/", "https://laanemaa.ee/", "https://www.laanevirumaauudised.ee/", "https://www.polvamaa.ee/", "https://parnumaa.ee/", "https://raplamaa.ee/", "https://visitsaaremaa.ee", "https://www.tartumaa.ee", "https://visitharju.ee", "https://www.hiiumaa.ee", "https://jarva.ee/", "https://vorumaa.ee", "http://www.vol.ee/", "https://www.valgamaa.ee" };
        public ContiesPicker()
        {
            picker = new Picker
            {
                Title="Conties of Estonia"
            };
            picker2 = new Picker
            {
                Title = "Center cities of Contie"
            };
            foreach (string i in conties)
            {
                picker.Items.Add(i);
            }
            foreach (string i in cities)
            {
                picker2.Items.Add(i);
            }
            lbl = new Label { HorizontalOptions = LayoutOptions.End, VerticalOptions=LayoutOptions.Start };
            more = new Button
            {
                Text="maakonna info",
                HorizontalOptions=LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            mk = new Image
            {

            };
            more.Clicked += More_Clicked;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            picker2.SelectedIndexChanged += Picker2_SelectedIndexChanged;
            wv = new WebView { };
            st1= new StackLayout
            {
                Children = { more,lbl}
            };
            st = new StackLayout
            {
                Children = { picker, picker2,st1}
            };
            Content = st;
        }


        private void More_Clicked(object sender, EventArgs e)
        {
            if (wv!=null)
            {
                st.Children.Remove(wv);
            }

                wv = new WebView
                {
                    Source = new UrlWebViewSource { Url = conties_URLs[picker.SelectedIndex] },
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                st.Children.Add(wv);
            
        }

        private void Picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker.SelectedIndex = picker2.SelectedIndex;
            lbl.Text = txt[picker2.SelectedIndex];
            
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            picker2.SelectedIndex = picker.SelectedIndex;
            lbl.Text = txt[picker.SelectedIndex];

            
        }
    }
}