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
    public partial class DataPicker : ContentPage
    {
        StackLayout st;
        DatePicker dp;
        Label emoj;
        Label sign;
        string[] zodiaks = { "pisces","tarturus","gemini","cancer","leo","aries","libra","scorpio","sagittarius","capricorn","aquarius"};
        string[] emoji = { "♓️", "♉️", "♋️", "♌️", "♈️","♎️","♏️","♐️","♑️","⛎️" };

        public DataPicker()
        {
            dp = new DatePicker
            {
                Format = "mm/dd/yyyy",
                MinimumDate = DateTime.Now.AddDays(-111),
                MaximumDate = DateTime.Now.AddDays(253),
            };
            Label lbl = new Label
            {
                Text = (dp.Date).ToString()
            };
            emoj =new Label { };
            sign = new Label { };
            st = new StackLayout
            {
                Children = {dp,lbl}
            };
            dp.DateSelected += Dp_DateSelected;
            Content = st;
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            /*var dateSelected = dp.Date;
            var pisesFrom = ("02/19/[0]", DateTime.Now.Year);
            if (dateSelected>=pisesFrom)
            {
                sign.Text = zodiaks[0];
                emoj.Text = emoji[0];
            }*/
        }
    }
}