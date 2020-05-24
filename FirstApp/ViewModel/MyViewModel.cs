using FirstApp.Model;
using System.ComponentModel;

namespace FirstApp.ViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private LabelModel model = new LabelModel();

        public string Label
        {
            get { return model.Label; }
            set
            {
                model.Label = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Label"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T target, T value)
        {
            if (Equals(target, value)) return;
            target = value;
        }

    }
}
