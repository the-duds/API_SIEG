using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;


namespace API_SIEG
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Digite o nome da empresa");
            string nome = Console.ReadLine();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Digite a chave ou Digite S para sair:");
                string chavenfe = Console.ReadLine();

                while (chavenfe.Length < 44 || chavenfe.Length > 44)
                {
                    if (chavenfe == "s")
                    {
                        Environment.Exit(0);
                    }
                    if (chavenfe == "S")
                    {
                        Environment.Exit(0);
                    }
                    Console.WriteLine("CHAVE INVALIDA - Digite a chave novamente ou Digite S para sair: ");
                    chavenfe = Console.ReadLine();
                }

                try
                {

                    string cnpj = chavenfe.Substring(6, 14);
                    string ano = chavenfe.Substring(2, 2);
                    string mes = chavenfe.Substring(4, 2);
                    string modelo = chavenfe.Substring(20, 2);
                    string xmltype = " ";

                    switch (ano)
                    {
                        case "19":
                            ano = "2019";
                            break;
                        case "20":
                            ano = "2020";
                            break;
                        case "21":
                            ano = "2021";
                            break;
                    }
                    switch (mes)
                    {
                        case "01":
                            mes = "Janeiro";
                            break;
                        case "02":
                            mes = "Fevereiro";
                            break;
                        case "03":
                            mes = "Março";
                            break;
                        case "04":
                            mes = "Abril";
                            break;
                        case "05":
                            mes = "Maio";
                            break;
                        case "06":
                            mes = "Junho";
                            break;
                        case "07":
                            mes = "Julho";
                            break;
                        case "08":
                            mes = "Agosto";
                            break;
                        case "09":
                            mes = "Setembro";
                            break;
                        case "10":
                            mes = "Outubro";
                            break;
                        case "11":
                            mes = "Novembro";
                            break;
                        case "12":
                            mes = "Dezembro";
                            break;
                    }
                    switch (modelo)
                    {
                        case "55":
                            xmltype = "nfe";
                            break;
                        case "65":
                            xmltype = "nfce";
                            break;
                        case "57":
                            xmltype = "cte";
                            break;
                        case "58":
                            xmltype = "mdfe";
                            break;
                        default:
                            Console.WriteLine("Documento Fiscal não suportado pelo SIEG.");
                            break;
                    }


                    string consumoapi = " ";
                    /*
                    Link do Web Service(https://api.sieg.com/aws/api-xml.ashx)
                    string linkapi = "https://api.sieg.com/aws/api-xml.ashx";
                    E - mail(Usuário do Cofre SIEG)
                    string emailapi = "api.sieg.nucleo@gmail.com";
                    ApiKey(Key fornecida pela SIEG, para liberar o acesso ao WEB Service)
                    OBS: Key única para cada usuário e intransferível.
                    */
                    string apikey = "https://up.sieg.com/aws/api-xml.ashx?apikey=Uqh2w9C5lqP4T9taitHAGA%3d%3d&email=api.sieg.nucleo@gmail.com";
                    //xmlkey(Chave do XML - 44 Dígitos)
                    string xmlkey = chavenfe;
                    //xmltype(Tipo do XML - "nfe", "cte", "nfse", "nfce", "cfe" )

                    consumoapi = apikey + "&" + "xmlkey=" + xmlkey + "&" + "xmltype=" + xmltype;


                    WebClient webClient = new WebClient();
                    //webClient.DownloadFile(consumoapi, @"c:\nfe\"+ chavenfe + ".xml");
                    webClient.DownloadFile(consumoapi, @"c:\nfe\" + chavenfe + ".xml");

                    string caminho = " ";
                    switch (xmltype)
                    {
                        case "nfe":
                            caminho = "c:\\SIEG\\NFe" + "\\" + nome + "\\" + mes + "-" + ano;
                            break;
                        case "cte":
                            caminho = "c:\\SIEG\\CTe" + "\\" + nome + "\\" + mes + "-" + ano;
                            break;
                        default:
                            Console.WriteLine("Tipo não identificado");
                            break;
                    }
                    //Console.WriteLine(caminho);
                    //string salvar = caminho;
                    string procurar = @"C:\nfe";
                    string sourceFile = System.IO.Path.Combine(procurar, (chavenfe + ".xml"));



                    StreamReader reader = new StreamReader(sourceFile);
                    string linha = " ";
                    string deletar = " ";

                    linha = reader.ReadLine();

                    if (linha == "{")
                    {
                        reader.Close();
                        deletar = "sim";
                        Console.WriteLine("!!ATENÇÃO!! - Documento não existe no SIEG - !!ATENÇÃO!!");
                        string modelo1 = chavenfe.Substring(20, 2);

                        switch (modelo1)
                        {
                            case "55":
                                xmltype = "nfe";
                                break;
                            case "65":
                                xmltype = "nfce";
                                break;
                            case "57":
                                xmltype = "cte";
                                break;
                            case "58":
                                xmltype = "mdfe";
                                break;
                            default:
                                Console.WriteLine("Documento Fiscal não suportado pelo SIEG.");
                                break;
                        }

                        string ano1 = chavenfe.Substring(2, 2);
                        string mes1 = chavenfe.Substring(4, 2);

                        switch (ano1)
                        {
                            case "18":
                                ano1 = "2018";
                                break;
                            case "19":
                                ano1 = "2019";
                                break;
                            case "20":
                                ano1 = "2020";
                                break;
                            case "21":
                                ano1 = "2021";
                                break;
                            default:
                                Console.WriteLine("Data do documento fiscal anterior ao SIEG.");
                                break;

                        }
                        switch (mes1)
                        {
                            case "01":
                                mes1 = "Janeiro";
                                break;
                            case "02":
                                mes1 = "Fevereiro";
                                break;
                            case "03":
                                mes1 = "Março";
                                break;
                            case "04":
                                mes1 = "Abril";
                                break;
                            case "05":
                                mes1 = "Maio";
                                break;
                            case "06":
                                mes1 = "Junho";
                                break;
                            case "07":
                                mes1 = "Julho";
                                break;
                            case "08":
                                mes1 = "Agosto";
                                break;
                            case "09":
                                mes1 = "Setembro";
                                break;
                            case "10":
                                mes1 = "Outubro";
                                break;
                            case "11":
                                mes1 = "Novembro";
                                break;
                            case "12":
                                mes1 = "Dezembro";
                                break;
                            default:
                                Console.WriteLine("Data do documento fiscal anterior ao SIEG.");
                                break;
                        }

                        string arquivo = "XML de NF-e não encontrados da empresa " + nome + ".txt";
                        string arquivo1 = "CHAVE PARA IMPORTAÇÃO NO SIEG empresa" + nome + ".txt";
                        string cnpj1 = chavenfe.Substring(6, 14);
                        string numnota1 = chavenfe.Substring(25, 9);


                        StreamWriter writer = new StreamWriter(@"C:\SIEG\" + arquivo, true);
                        using (writer)
                        {
                            // Escreve uma nova linha no final do arquivo
                            writer.WriteLine("CNPJ Emitente: " + cnpj1 + " | Numero da NF-e: " + numnota1 + " | Emissão: " + mes1 + " - " + ano1 + " | Chave NF-e: " + chavenfe);
                        }

                        StreamWriter writer1 = new StreamWriter(@"C:\SIEG\" + arquivo1, true);
                        using (writer1)
                        {
                            // Escreve uma nova linha no final do arquivo
                            writer1.WriteLine(chavenfe);
                        }

                    }
                    else if (deletar == "sim")
                    {
                        reader.Close();
                        File.Delete(sourceFile);
                    }
                    else
                    {


                        // Crie uma nova pasta de destino.
                        // Se o diretório já existir, este método não cria um novo diretório.
                        Directory.CreateDirectory(caminho);
                        string destFile = System.IO.Path.Combine(caminho, (chavenfe + ".xml"));
                        // Para copiar um arquivo para outro local e
                        // sobrescreve o arquivo de destino, se ele já existir.
                        File.Copy(sourceFile, destFile, true);
                        reader.Close();
                        Console.WriteLine("Download Concluído!");

                    }


                }



                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("!!ATENÇÃO!! - Documento não existe no SIEG - !!ATENÇÃO!!");
                    string modelo = chavenfe.Substring(20, 2);


                    string xmltype = " ";

                    switch (modelo)
                    {
                        case "55":
                            xmltype = "nfe";
                            break;
                        case "65":
                            xmltype = "nfce";
                            break;
                        case "57":
                            xmltype = "cte";
                            break;
                        case "58":
                            xmltype = "mdfe";
                            break;
                        default:
                            Console.WriteLine("Documento Fiscal não suportado pelo SIEG.");
                            break;
                    }

                    string ano = chavenfe.Substring(2, 2);
                    string mes = chavenfe.Substring(4, 2);

                    switch (ano)
                    {
                        case "19":
                            ano = "2019";
                            break;
                        case "20":
                            ano = "2020";
                            break;
                        case "21":
                            ano = "2021";
                            break;
                    }
                    switch (mes)
                    {
                        case "01":
                            mes = "Janeiro";
                            break;
                        case "02":
                            mes = "Fevereiro";
                            break;
                        case "03":
                            mes = "Março";
                            break;
                        case "04":
                            mes = "Abril";
                            break;
                        case "05":
                            mes = "Maio";
                            break;
                        case "06":
                            mes = "Junho";
                            break;
                        case "07":
                            mes = "Julho";
                            break;
                        case "08":
                            mes = "Agosto";
                            break;
                        case "09":
                            mes = "Setembro";
                            break;
                        case "10":
                            mes = "Outubro";
                            break;
                        case "11":
                            mes = "Novembro";
                            break;
                        case "12":
                            mes = "Dezembro";
                            break;
                    }

                    string arquivo = "XML de NF-e não encontrados da empresa " + nome + ".txt";
                    string cnpj = chavenfe.Substring(6, 14);
                    string numnota = chavenfe.Substring(25, 9);

                    StreamWriter writer = new StreamWriter(@"C:\SIEG\" + arquivo, true);
                    using (writer)
                    {
                        // Escreve uma nova linha no final do arquivo
                        writer.WriteLine("CNPJ Emitente: " + cnpj + " | Numero da NF-e: " + numnota + " | Emissão: " + mes + " - " + ano + " | Chave NF-e: " + chavenfe);
                    }


                }


                catch (System.Net.WebException)
                {

                    Console.WriteLine("!!ATENÇÃO!! - Documento não existe no SIEG - !!ATENÇÃO!!");

                    string modelo = chavenfe.Substring(20, 2);
                    string xmltype = " ";

                    switch (modelo)
                    {
                        case "55":
                            xmltype = "nfe";
                            break;
                        case "65":
                            xmltype = "nfce";
                            break;
                        case "57":
                            xmltype = "cte";
                            break;
                        case "58":
                            xmltype = "mdfe";
                            break;
                        default:
                            Console.WriteLine("Documento Fiscal não suportado pelo SIEG.");
                            break;
                    }

                    string ano = chavenfe.Substring(2, 2);
                    string mes = chavenfe.Substring(4, 2);

                    switch (ano)
                    {
                        case "19":
                            ano = "2019";
                            break;
                        case "20":
                            ano = "2020";
                            break;
                        case "21":
                            ano = "2021";
                            break;
                    }
                    switch (mes)
                    {
                        case "01":
                            mes = "Janeiro";
                            break;
                        case "02":
                            mes = "Fevereiro";
                            break;
                        case "03":
                            mes = "Março";
                            break;
                        case "04":
                            mes = "Abril";
                            break;
                        case "05":
                            mes = "Maio";
                            break;
                        case "06":
                            mes = "Junho";
                            break;
                        case "07":
                            mes = "Julho";
                            break;
                        case "08":
                            mes = "Agosto";
                            break;
                        case "09":
                            mes = "Setembro";
                            break;
                        case "10":
                            mes = "Outubro";
                            break;
                        case "11":
                            mes = "Novembro";
                            break;
                        case "12":
                            mes = "Dezembro";
                            break;
                    }

                    string arquivo = "XML de CT-e não encontrados da empresa " + nome + ".txt";
                    string cnpj = chavenfe.Substring(6, 14);
                    string numnota = chavenfe.Substring(25, 9);

                    StreamWriter writer = new StreamWriter(@"C:\SIEG\" + arquivo, true);
                    using (writer)
                    {
                        // Escreve uma nova linha no final do arquivo
                        writer.WriteLine("CNPJ Emitente: " + cnpj + " | Numero da CT-e: " + numnota + " | Emissão: " + mes + " - " + ano + " | Chave CT-e: " + chavenfe);

                    }
                }
            }
        }
    }
}
// Programa criado por Eduardo Fernandes - edu.hspf@gmail.com - 31 975815890