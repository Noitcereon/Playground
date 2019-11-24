using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Playground.Annotations;
using Playground.Models;

namespace Playground.Model
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Animal> _animals;

        public MainViewModel()
        {
            string imagePather = "../Assets/";
            _animals = new List<Animal>
            {
                new Animal("Lion", "../Assets/lions.jpg", "The lion (Panthera leo) is a species in the family Felidae; it is a muscular," +
                                         " deep-chested cat with a short, rounded head, a reduced neck and round ears, and a hairy tuft at the end of its tail."), 
                new Animal("Wolf", "../Assets/wolves.jpg", "Wolf description"),
                new Animal("Panda", imagePather + "pandas.jpg", "Panda description"),
                new Animal("Red panda", imagePather + "Red Panda.jpg", "Red panda description"),
                new Animal("Meerkat", imagePather + "Meerkats.jpg", "Meerkat description"),
                new Animal("Gecko", imagePather + "Gecko.jpg", "Gecko description"),
                new Animal("Kiwi", imagePather + "Kiwi.jpg", "Kiwi description"),
                new Animal("Elephant", imagePather + "Elephant.jpg", "Elephant description"),
                new Animal("Hippopotamus", imagePather + "Hippopotamus.jpg", "Hippo description")
            };
        }

        public List<Animal> Animals
        {
            get { return _animals; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AddNewAnimal(string species, string imagePath, string description)
        {
            Animal newAnimal = new Animal(species, imagePath, description);
            _animals.Add(newAnimal);
        }
    }
}
