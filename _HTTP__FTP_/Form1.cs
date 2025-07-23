using System;
using System.Net;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace _HTTP__FTP_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                try
                {
                    string query = "https://dou.ua/";

                    // HttpClient - класс для отправки HTTP-запросов и получения HTTP-ответов от ресурса,
                    // указанного URI (единообразный идентификатор ресурса).
                    HttpClient httpClient = new HttpClient();

                    // HttpResponseMessage представляет сообщение ответа HTTP, включая код статуса и данные.
                    HttpResponseMessage message = await httpClient.GetAsync(query);

                    // ReadAsStream сериализирует содержимое HTTP и возвращает поток, представляющий содержимое
                    Stream stream = message.Content.ReadAsStream();

                    StreamReader sr = new StreamReader(stream, Encoding.UTF8);

                    // считываем данные из потока в строку
                    string data = sr.ReadToEnd();

                    // сохраняем полученные данные в файл
                    StreamWriter sw = new StreamWriter("../../dou_ua.html", false);
                    sw.WriteLine(data);
                    MessageBox.Show("Файл успешно загружен с сервера!");
                    sw.Close();               
                    sr.Close();  
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await Task.Run(async() =>
            {
                try
                {
                    string query = "https://dou.ua/";

                    // HttpClient - класс для отправки HTTP-запросов и получения HTTP-ответов от ресурса,
                    // указанного URI (единообразный идентификатор ресурса).
                    HttpClient httpClient = new HttpClient();

                    //  ReadAsByteArrayAsync сериализирует содержимое HTTP в массив байтов
                    byte[] urlData = await httpClient.GetByteArrayAsync(query);

                    // преобразуем данные в строку
                    string data = Encoding.UTF8.GetString(urlData);

                    // сохраняем полученные данные в файл
                    StreamWriter sw = new StreamWriter("../../dou-ua.html", false);
                    await sw.WriteLineAsync(data);
                    sw.Close();
                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await Task.Run(async() =>
            {
                try
                {
                    string query = "https://download.microsoft.com/download/B/A/5/BA57BADE-D558-4693-8F82-29E64E4084AB/HDI-ITPro-MSDN-winvideo-CodeFirstNewDatabase.wmv";
                    // HttpClient - класс для отправки HTTP-запросов и получения HTTP-ответов от ресурса,
                    // указанного URI (единообразный идентификатор ресурса).
                    HttpClient httpClient = new HttpClient();

                    //  ReadAsByteArrayAsync сериализирует содержимое HTTP в массив байтов
                    byte[] urlData = await httpClient.GetByteArrayAsync(query);

                    // сохраняем полученные данные в файл
                    FileStream fileStream = new FileStream("../../GoToDefinition.wmv", FileMode.Create, FileAccess.Write);
                    BinaryWriter writer = new BinaryWriter(fileStream);
                    writer.Write(urlData, 0, urlData.Length);
                    writer.Close();
                    fileStream.Close();
                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await Task.Run(async() =>
            {
                try
                {
                    string query = "https://dou.ua/";

                    // HttpClient - класс для отправки HTTP-запросов и получения HTTP-ответов от ресурса,
                    // указанного URI (единообразный идентификатор ресурса).
                    HttpClient httpClient = new HttpClient();

                    // GetStreamAsync отправляет GET-запрос на указанный URI и возвращает ответ в виде потока
                    Stream stream = await httpClient.GetStreamAsync(query);

                    StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
                    FileInfo fiData = new FileInfo("../../dou.html");
                    StreamWriter streamWriter = fiData.CreateText(); // создаем новый файл
                    await streamWriter.WriteLineAsync(await streamReader.ReadToEndAsync()); // записываем в него строку
                    streamWriter.Close();
                    streamReader.Close();
                    stream.Close();
                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await Task.Run(async() =>
            {
                try
                {
                    // URI, определяющий интернет-ресурс 
                    // URI (англ. Uniform Resource Identifier) — единообразный идентификатор ресурса
                    string query = "https://la-torta.ua/content/images/2/284x402l50nn0/sakharnaia-kartynka-lylo-y-stych-3-20x30sm-82623750326345.png";

                    // HttpClient - класс для отправки HTTP-запросов и получения HTTP-ответов от ресурса,
                    // указанного URI (универсальный код ресурса).
                    HttpClient httpClient = new HttpClient();
                    // HttpResponseMessage представляет сообщение ответа HTTP, включая код статуса и данные.
                    HttpResponseMessage message = await httpClient.GetAsync(query);

                    // ReadAsStream сериализирует содержимое HTTP и возвращает поток, представляющий содержимое
                    Stream stream = message.Content.ReadAsStream();
                    byte[] b = new byte[(long)message.Content.Headers.ContentLength];
                    int c = 0;
                    int i = 0;
                    while ((c = stream.ReadByte()) != -1)
                    {
                        b[i++] = (byte)c;
                    }
                    // сохраняем полученные данные в файл
                    FileStream st = new FileStream("../../Birthday.png", FileMode.OpenOrCreate);
                    BinaryWriter writer = new BinaryWriter(st);
                    writer.Write(b);
                    writer.Close();
                    MessageBox.Show("Файл успешно загружен с сервера!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                   FtpWebRequest request = WebRequest.Create("ftp://komphort.ru/") as FtpWebRequest;

                    // ListDirectoryDetails представляет метод протокола FTP LIST, 
                    // который возвращает подробный список файлов на FTP-сервере.
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                    // Получим ответ на ftp-запрос
                    FtpWebResponse response = request.GetResponse() as FtpWebResponse;

                    // Возвращаем поток данных из полученного интернет-ресурса
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string res = reader.ReadToEnd();
                    // сохраняем полученные данные в файл
                    StreamWriter sw = new StreamWriter("../../list.txt", false);

                    sw.WriteLine(res);
                    sw.Close();
                    MessageBox.Show("Список директорий сохранен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    // URI, определяющий интернет-ресурс 
                    // URI (англ. Uniform Resource Identifier) — единообразный идентификатор ресурса
                    // Инициализируем новый экземпляр WebRequest
                    string URI = "ftp://ftp.intel.com/images/UserTroubleshootingPic1.jpg";
                    FtpWebRequest request = WebRequest.Create(URI) as FtpWebRequest;

                    // Получим ответ на ftp-запрос
                    FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                    Stream stream = response.GetResponseStream();
                    List<byte> list = new List<byte>();
                    int c = 0;
                    while ((c = stream.ReadByte()) != -1)
                    {
                        list.Add((byte)c);
                    }
                    // сохраняем полученные данные в файл
                    FileStream st = new FileStream("../../picture.jpg", FileMode.OpenOrCreate);
                    BinaryWriter writer = new BinaryWriter(st);
                    writer.Write(list.ToArray());
                    writer.Close();
                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
