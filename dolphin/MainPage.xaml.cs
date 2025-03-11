using System.Collections.ObjectModel;

namespace dolphin
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<DolphinModel> Dolphins { get; set; }
        public ObservableCollection<DolphinModel> FilteredDolphins { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Dolphins = new ObservableCollection<DolphinModel>
            {
                new DolphinModel { Name = "Китайский дельфин", Description = "Вид водных млекопитающих из парвотряда зубатых китов",  Image = "china.png" },
                new DolphinModel { Name = "Темный дельфин", Description = "Вид из семейства дельфинов, входящий в род Sagmatias", Image = "dark.png" },
                new DolphinModel { Name = "Серый", Description = "Вид млекопитающих семейства дельфиновых", Image = "gray.png" },
                new DolphinModel { Name = "Камерсон", Description = "Один из самых маленьких китообразных", Image = "kamerson.png" },
                new DolphinModel { Name = "Касатка", Description = "Морское млекопитающее семейства дельфиновых", Image = "kasatka.jpg" },
                new DolphinModel { Name = "Розовый дельфин", Description = "Вид водных млекопитающих из парвотряда зубатых китов, представитель группы речных дельфинов.", Image = "pink.png" },
                new DolphinModel { Name = "Белый", Description = "Вид дельфиновых, встречающийся в реках бассейна Амазонки", Image = "white.png" }
            };

            FilteredDolphins = new ObservableCollection<DolphinModel>(Dolphins);
            BindingContext = this;
        }
        public class DolphinModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue?.ToLower() ?? "";
            FilteredDolphins.Clear();

            foreach (var dolphin in Dolphins)
            {
                if (dolphin.Name.ToLower().Contains(searchText))
                {
                    FilteredDolphins.Add(dolphin);
                }
            }
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var dolphinToDelete = (DolphinModel)button.BindingContext;

            if (dolphinToDelete != null)
            {
                FilteredDolphins.Remove(dolphinToDelete);  
            }
        }
    }

}
