using PlasticInjectionApp.Models;
using PlasticInjectionApp.Services;

namespace PlasticInjectionApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCompareClicked(object sender, EventArgs e)
        {
            string searchCode = MouldCodeEntry.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(searchCode))
            {
                DisplayAlert("خطأ", "يرجى إدخال كود القالب", "موافق");
                return;
            }

            double vMargin = double.TryParse(VMarginEntry.Text, out double v) ? v : 15;
            double hMargin = double.TryParse(HMarginEntry.Text, out double h) ? h : 15;

            // آلة افتراضية واختبار القالب
            var sampleMachine = new Machine 
            { 
                Name = "Machine 01 (300T)", 
                WMin = 200, WMax = 600, VMin = 300, HMin = 250, 
                ForceVerrouillage = 3000, PoidsMouleMax = 1500 
            };

            var sampleMould = new Mould 
            { 
                Code = searchCode, Name = searchCode, 
                Width = 400, Length = 290, Height = 240, 
                ForceVerrouillage = 2500, Weight = 1200 
            };

            var result = ComparisonEngine.Compare(sampleMould, sampleMachine, vMargin, hMargin);

            ResultsListView.ItemsSource = new List<ComparisonResult> { result };
            ResultHeaderLabel.Text = $"نتيجة الفحص للقالب: {searchCode}";
            ResultHeaderLabel.IsVisible = true;
        }
    }
}
