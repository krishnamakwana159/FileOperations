using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int choice;            
            do
            {
                Console.WriteLine("1. Create a file \n2. Copy a file \n3. Rename a file \n4. Write File \n5. Delete File \n6. Concatenate two files \n7. Display contents of a file \n8. Exit");
                Console.WriteLine("Enter Your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        program.createFile();
                        break;
                    case 2:
                        program.copyFile();
                        break;
                    case 3:
                        program.renameFile();
                        break;
                    case 4:
                        program.writeFile();
                        break;
                    case 5:
                        program.deleteFile();
                        break;
                    case 6:
                        program.concacteFile();
                        break;
                    case 7:
                        program.displayFileContent();
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice !!");
                        break;
                }
            } while (choice != 8);
        }

        public void writeFile()
        {
            Console.WriteLine("Enter Name of file to Write : ");
            string name = Console.ReadLine() + ".txt";
            string path = "‪D://" + name ;           

            if (File.Exists(path))
            {
                Console.WriteLine("\tWrite Content of File Here....");
                var content = Console.ReadLine();
                StreamWriter sw = new StreamWriter(path);
                sw.Write(content);
                sw.Close();
                Console.WriteLine("\tAdded Successfully !!! ");
            }
            else
            {
                Console.WriteLine("\tFile does not Exist !!");
            }
        }

        private void deleteFile()
        {
            Console.WriteLine("Enter Name of file to Delete : ");
            string name = Console.ReadLine() + ".txt";
            string path = "‪D://" + name;

            if (File.Exists(path))
            {
                File.Delete(path);
            }               
        }

        public void displayFileContent()
        {
            Console.WriteLine("Enter Name of file to Display : ");
            string name = Console.ReadLine();
            string path = "‪D://" + name + ".txt";

            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                Console.WriteLine("\tFile Contents are : ");
                string code;
                while ((code = sr.ReadLine()) != null)
                {
                    Console.WriteLine(code);
                }
                sr.Close();
            }
            else
            {                
                Console.WriteLine("\tFile does not exists !! ");
            }
        }

        public void concacteFile()
        {
            Console.WriteLine("Enter First Filename for Contactination : ");
            string fname = Console.ReadLine() + ".txt";
            Console.WriteLine("Enter Second Filename  : ");
            string sname = Console.ReadLine() + ".txt";

            string FilePath = "D://" + fname;

            if (File.Exists(FilePath))
            {
                FilePath = "‪D://" + sname;
                if(File.Exists(FilePath))
                {
                    FileStream fileStream = new FileStream("‪D://" + fname + ".txt", FileMode.Append);
                    FileStream fileStream1 = new FileStream("D://" + sname + ".txt", FileMode.Open);

                    StreamReader streamReader = new StreamReader(fileStream1);
                    string code;
                    while((code =streamReader.ReadLine()) != null)
                    {
                        StreamWriter streamWriter = new StreamWriter(fileStream);
                        streamWriter.WriteLine(code);
                        streamWriter.Close();
                    }
                    streamReader.Close();
                }
                Console.WriteLine("\tFile Concatenate Successfully !!!");
            }
            else
            {
                Console.WriteLine("\tFile does not exists !! ");
            }
            
        }

        public void renameFile()
        {
            Console.WriteLine("Enter Filename Which u want to Rename: ");
            string name = Console.ReadLine() + ".txt";
            Console.WriteLine("Enter New Name of a File : ");
            string new_name = Console.ReadLine() + ".txt";
            string path = "‪D://" + name;

            FileInfo fileInfo = new FileInfo(path);
            if(fileInfo.Exists)
            {
                fileInfo.MoveTo("D://" + new_name + ".txt");
                Console.WriteLine("\tFile Renamed !!");
            }
            else
            {
                Console.WriteLine("\tFile does not exists !!");
            }
        }

        public void copyFile()
        {
            Console.WriteLine("Enter Filename to Copy :");
            string sourceFile = Console.ReadLine();
            Console.WriteLine("Enter Destination filename : ");
            string destFile = Console.ReadLine();
            

            File.Delete("‪D://" + sourceFile + ".txt");
            File.Copy("‪D://" + sourceFile + ".txt" , "‪D:/" + destFile + ".txt");
            Console.WriteLine("\tFile copied Successfully !!!");

        }

        public void createFile()
        {
            Console.WriteLine("Enter Name of file which u want to create : ");
            string name = Console.ReadLine();
            string FilePath = "D://" + name +".txt";           

            if (File.Exists(FilePath))
            {
                Console.WriteLine("\tFile is already exists !!");
            }
            else
            {
                var f = File.CreateText(FilePath);
                Console.WriteLine("\tFile is created successfully !!");
                f.Close();
            }
        }
    }
}
