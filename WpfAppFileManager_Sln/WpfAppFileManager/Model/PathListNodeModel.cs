using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppFileManager
{
    public class PathListNode : INotifyPropertyChanged
    {
        // модель хранения директорий 
		
		private string file_name;
        private string destination_path;
        private string source_path;

        

        public string Destination_path
        {
            get { return destination_path; }
            set
            {
                destination_path = value;
                OnPropertyChanged("Destination_path");
            }
        }


        public string File_name
        {
            get { return file_name; }
            set
            {
                file_name = value;
                OnPropertyChanged("File_name");
            }
        }

        public string Source_path
        {
            get { return source_path; }
            set
            {
                source_path = value;
                OnPropertyChanged("Source_path");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
