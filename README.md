# Test-task-from-veeam

Приложение разделил на следующие части:
- ApplicationViewModel реализует основную логигику 
- LogNodeModel и PathListNodeModel являются моделями для хранения узлов жарнала и списка путей файлов
- FileManager выполняет задачи копирования и создания файлов (каждая задача по завершению записывается в журнал)
- Serializer выполняет задачу считывания файла настроек (каждая задача по завершению записывается в журнал)

Resource папка для хранения файла настроек.
