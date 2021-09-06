using System;
using System.Xml;
using System.Collections.ObjectModel;

namespace WpfAppFileManager
{
    class Serializer
    {
        // класс Serializer выполняет задачу считывания файла настроек
		// по завершению считывания делается запись в журнал
		
		public static void Deserialize(ObservableCollection<PathListNode> List_paths,  ObservableCollection<LogNode> Log)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Resource\config.xml");
                XmlElement rootNode = doc.DocumentElement;

                foreach (XmlNode childNode in rootNode.ChildNodes)
                {
                    string source_path = childNode.Attributes["source_path"].Value.ToString();
                    string destination_path = childNode.Attributes["destination_path"].Value.ToString();
                    string file_name = childNode.Attributes["file_name"].Value.ToString();

                    PathListNode path_List_Node = new PathListNode();
                    path_List_Node.Destination_path = destination_path;
                    path_List_Node.Source_path = source_path;
                    path_List_Node.File_name = file_name;

                    List_paths.Insert(0, path_List_Node);
                }

                DateTime now = DateTime.Now;
                LogNode log_Node = new LogNode();

                log_Node.Date_time = now.ToString("F");
                log_Node.Status = "Считывание файла настроек, успешно завешено.";
                Log.Insert(0, log_Node);
            }
            catch (Exception ex)
            {
                DateTime now = DateTime.Now;

                LogNode log_Node = new LogNode();
                log_Node.Date_time = now.ToString("F");
                log_Node.Status = $"Считывание файла настроек не выполнено! {ex.Message}";
                Log.Insert(0, log_Node);
            }

        }
    }
}
