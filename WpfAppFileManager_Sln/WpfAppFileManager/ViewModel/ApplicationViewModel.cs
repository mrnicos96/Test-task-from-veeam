using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfAppFileManager
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
		
        public ObservableCollection<PathListNode> List_paths { get; set; }   // хранит пути считанные из конфигурационного файла
        public ObservableCollection<LogNode> Log { get; set; }               // хранит события 


        private bool buttoneAvailible;
        
        
        private RelayCommand  readConfigCommand;
        private RelayCommand  createFilesCommand;
        private RelayCommand  copyFilesCommand;


        // закрывает доступ к кннопкам "Создать файлы" и "Копировать файлы"
		public bool ButtoneAvailible
        {
            get { return buttoneAvailible; }
            set
            {
                buttoneAvailible = value;
                OnPropertyChanged("ButtoneAvailible");
            }
        }


        // реализация команды "Считать файл настроек"
        public RelayCommand ReadConfigCommand
        {
            get
            {
                return readConfigCommand ??
                  (readConfigCommand = new RelayCommand(obj =>
                  {
                      List_paths.Clear();
                      Serializer.Deserialize(List_paths, Log);
                      ButtoneAvailible = true;
                  }));
            }
        }

        
		// реализация команды "Создать файлы"
        public RelayCommand CreateFilesCommand
        {
            get
            {
                return createFilesCommand ??
                  (createFilesCommand = new RelayCommand(obj =>
                  {
                      FileManager.CreateFiles(List_paths, Log);
                  }));
            }
        }

        
		// реализация команды "Копировать файлы"
		public RelayCommand СopyFilesCommand
        {
            get
            {
                return copyFilesCommand ??
                  (copyFilesCommand = new RelayCommand(obj =>
                  {
                      FileManager.CopyFiles(List_paths, Log);
                  }));
            }
        }

        public ApplicationViewModel()
        {
            List_paths = new ObservableCollection<PathListNode>();
            Log = new ObservableCollection <LogNode>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
