using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    static void Main()
    {
       

        // Charger les documents XML
        XmlDocument firstXmlDoc = new XmlDocument();
        firstXmlDoc.Load("C:/Projet/1_Itération_finale/ENS/Source/Notices/test/output_mytext.xml");

        XmlDocument secondXmlDoc = new XmlDocument();
        secondXmlDoc.Load("C:/Projet/1_Itération_finale/ENS/Source/Notices/test/Export_REVUE_22052023_1726_00001.xml");


        /*subscription + collection
        // Parcourir les nœuds "row" du premier fichier XML
        XmlNodeList firstRowNodes = firstXmlDoc.SelectNodes("//row");
        XmlNodeList secondRowNodes = secondXmlDoc.SelectNodes("//row");
        foreach (XmlNode firstRowNode in firstRowNodes)
        {
            XmlNode fieldNode = firstRowNode.SelectSingleNode("field[@name='id']");
            XmlNode fieldNodeAlo = firstRowNode.SelectSingleNode("field[@name='alo_id']");

            string id = fieldNode.InnerText;
            string alo_id = fieldNodeAlo.InnerText;
          //  Console.WriteLine("id= " + id + " alo=" + alo_id);
            foreach (XmlNode secondRowNode in secondRowNodes)
            {
                XmlNode subscriptionNodie = secondRowNode.SelectSingleNode("field[@name='subscription_id']");
                string subscription = subscriptionNodie.InnerText;
                if (subscription == id)
                {

                    // Créer un nouvel élément
                    XmlElement nouvelElement = secondXmlDoc.CreateElement("field");
                    nouvelElement.SetAttribute("name","alo_id");
                    // Définir la valeur de l'élément
                    nouvelElement.InnerText = alo_id;

                    // Ajouter le nouvel élément au nœud "row"
                    secondRowNode.AppendChild(nouvelElement);


                }

            }

        }
        // Enregistrer les modifications dans le fichier XML
        secondXmlDoc.Save("C:/Users/Archimed/Downloads/output_mytext.xml");
        */

        /*ouput + rev */
        // Parcourir les nœuds "row" du premier fichier XML
        XmlNodeList firstRowNodes = firstXmlDoc.SelectNodes("//row");
        XmlNodeList secondRowNodes = secondXmlDoc.SelectNodes("//record");
        
        foreach (XmlNode firstRowNode in firstRowNodes)
        {
            XmlNode fieldNode = firstRowNode.SelectSingleNode("field[@name='alo_id']");
            XmlNode fieldNodeAperiod = firstRowNode.SelectSingleNode("field[@name='aperiod']");
            XmlNode fieldNodeDetail = firstRowNode.SelectSingleNode("field[@name='detail']");


            string detail = fieldNodeDetail?.InnerText;

            string alo_id = fieldNode?.InnerText;
            string aperiod = fieldNodeAperiod?.InnerText;
            

          




                //  Console.WriteLine("id= " + id + " alo=" + alo_id);
                foreach (XmlNode secondRowNode in secondRowNodes)
            {
                string id2 = secondRowNode.Attributes["id"].Value;
                
                if (id2 == alo_id)
                {

                    // Créer un nouvel élément
                    XmlElement nouvelElement = secondXmlDoc.CreateElement("field");
                    nouvelElement.SetAttribute("name","col");
                    // Définir la valeur de l'élément
                    nouvelElement.InnerText = aperiod+" "+detail;

                    // Ajouter le nouvel élément au nœud "row"
                    secondRowNode.AppendChild(nouvelElement);


                }

            }
           

        }
        // Enregistrer les modifications dans le fichier XML
        secondXmlDoc.Save("C:/Users/Archimed/Downloads/Rev_coll.xml");
        

    }
}
