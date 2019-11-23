using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Models
{
    /// <summary>
    /// Model class for animals
    /// </summary>
    public class Animal
    {
        #region Instance Fields
        private string _animalRace;
        private string _imagePath;
        private string _description;
        #endregion

        public Animal(){}

        public Animal(string race, string imagePath, string description)
        {
            _animalRace = race;
            _imagePath = imagePath;
            _description = description;
        }

        public string AnimalRace
        {
            get => _animalRace;
            set => _animalRace = value;
        }

        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }
    }
}
