﻿using System.Xml.Serialization;

namespace ZMap.SLD;

public class CoverageStyle
{
    [XmlElement("Name")] public string Name { get; set; }

    [XmlElement("Description")] public Description Description { get; set; }

    [XmlElement("CoverageName")] public string CoverageName { get; set; }

    public string[] SemanticTypeIdentifier { get; set; }
    // public void ReadXml(XmlReader reader)
    // {
    //     var semanticTypeIdentifier = new List<string>();
    //     while (reader.Read())
    //     {
    //         if (reader.LocalName == "CoverageStyle" && reader.NodeType == XmlNodeType.EndElement)
    //         {
    //             break;
    //         }
    //         else
    //             switch (reader.LocalName)
    //             {
    //                 case "Name" when reader.NodeType == XmlNodeType.Element:
    //                     Name = reader.ReadString();
    //                     break;
    //                 case "Description" when reader.NodeType == XmlNodeType.Element:
    //                     var description = new Description();
    //                     description.ReadXml(reader);
    //                     Description = description;
    //                     break;
    //                 case "CoverageName" when reader.NodeType == XmlNodeType.Element:
    //                     CoverageName = reader.ReadString();
    //                     break;
    //                 case "SemanticTypeIdentifier" when reader.NodeType == XmlNodeType.Element:
    //                     var val = reader.ReadString();
    //                     semanticTypeIdentifier.Add(val);
    //                     break;
    //             }
    //     }
    //     SemanticTypeIdentifier = semanticTypeIdentifier.ToArray();
    // }
}