using System;
using System.IO;
using System.Collections.ObjectModel;

namespace WpfAppFileManager
{
    class FileManager
    {
        // класс FileManager решает две задачи: копирование файлов и создание файлов 
		// состаяние задачи сохраняется в журнал, в случае исключения выводится подсказка по исправлению ошибки
		
		
		public static void CopyFiles(ObservableCollection<PathListNode> List_paths, ObservableCollection<LogNode> Log)
        {
            foreach (PathListNode node in List_paths)
            {
                try
                {
                    Copy(node.Source_path, @node.Destination_path, node.File_name, Log);
                }
                catch (UnauthorizedAccessException ex)
                {
                    DateTime now = DateTime.Now;
                    
                    LogNode log_Node = new LogNode();
                    log_Node.Date_time = now.ToString("F");
                    log_Node.Status = $"Копирование {node.File_name} не выполнено! {ex.Message} Запустите приложение с правами администратора.";
                    Log.Insert(0, log_Node);
                }

                catch (DirectoryNotFoundException ex)
                {
                    DateTime now = DateTime.Now;
                    LogNode log_Node = new LogNode();
                    log_Node.Date_time = now.ToString("F");
                    log_Node.Status = $"Копирование {node.File_name} не выполнено! {ex.Message} Подсказка: Файл можно создать нажав на кнопку <Создать файлы>.";
                    Log.Insert(0, log_Node);
                }
                catch (Exception ex)
                {
                    DateTime now = DateTime.Now;
                    LogNode log_Node = new LogNode();
                    log_Node.Date_time = now.ToString("F");
                    log_Node.Status = $"Не удалось выполнить копирование файла {node.File_name}! {ex.Message}";
                    Log.Insert(0, log_Node);
                }
            }
            
        }
        public static void Copy(string source_path, string destination_path, string file_name, ObservableCollection<LogNode> Log)
        {
            DirectoryInfo directory_Info = new DirectoryInfo(destination_path); 
            FileInfo file_Inf = new FileInfo(source_path + "/" + file_name);

            if (!directory_Info.Exists)
                directory_Info.Create();
            
            
            file_Inf.CopyTo(destination_path + "/" + file_name, true);


            DateTime now = DateTime.Now;
            LogNode log_Node = new LogNode();


            log_Node.Date_time = now.ToString("F");
            log_Node.Status = $"Копирование файла {file_name}, Успешно завешено!";
            Log.Insert(0, log_Node);
            return;
        }
        public static void CreateFiles(ObservableCollection<PathListNode> List_paths, ObservableCollection<LogNode> Log)
        {
            foreach (PathListNode node in List_paths)
            {
                try
                {
                    Create_File(node.Source_path, node.File_name, Log);
                }
                catch (Exception ex)
                {
                    DateTime now = DateTime.Now;
                    LogNode log_Node = new LogNode();
                    log_Node.Date_time = now.ToString("F");
                    log_Node.Status = $"Не удалось выполнить создание файла {node.File_name}! {ex.Message}";
                    Log.Insert(0, log_Node);
                }

            }
                
        }
        public static void Create_File(string source_path,  string file_name, ObservableCollection<LogNode> Log)
        {
            DirectoryInfo directory_Info = new DirectoryInfo(source_path);
            FileInfo file_Inf = new FileInfo(source_path + "/" + file_name);
            

            if (!directory_Info.Exists)
                directory_Info.Create();
            file_Inf.Create();            
            
            
            DateTime now = DateTime.Now;
            LogNode log_Node = new LogNode();

            log_Node.Date_time = now.ToString("F");
            log_Node.Status = $"Создание файла {file_name}, успешно завешено.";
            Log.Insert(0, log_Node);
            return;
        }
    }
}
