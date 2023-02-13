using UnityEngine;
using UnityEditor;
using System.Xml;
using System;
using System.Collections.Generic;
using System.IO;

public class Pokedex : MonoBehaviour {


	[MenuItem("Pokedex/Clean XML")]
	static void XMLCleaner() {
	}

	[MenuItem("Pokedex/Create")]
	static void CreatePokedex() {
		string id = "00";
		int idNumber = 0;
		string idDef = "";
		var spirtes = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/pokedex.png");
		XmlDocument doc = new XmlDocument();
		doc.Load("Assets/XML/pokedex_fixed.xml");
		XmlNode firstChild = doc.ChildNodes[1];
		List<XmlNode> toRemove = new List<XmlNode>();
		foreach (XmlNode node in firstChild.ChildNodes)
		{			
			PokemonScriptableObject pokemonSO = ScriptableObject.CreateInstance<PokemonScriptableObject>();
			pokemonSO.type = new List<Type>();
			pokemonSO.id = int.Parse(node.Attributes["id"].Value);
			pokemonSO.sprite = (Sprite) spirtes[pokemonSO.id-1];
			foreach (XmlNode node2 in node.ChildNodes)
			{			
				if(node2.Name == "name")
                {
					pokemonSO.pokemonName = node2.InnerText;
                }
				if (node2.Name == "type")
				{
					Type type;
					Enum.TryParse(node2.InnerText, out type);
                    pokemonSO.type.Add(type);				
				}
				if(node2.Name == "description")
                {
					pokemonSO.description = node2.InnerText;
                }
				if (node2.Name == "stats")
				{
					foreach (XmlNode node3 in node2.ChildNodes)
					{

						if (node3.Name == "HP")
						{
							pokemonSO.stats.HP = int.Parse(node3.InnerText);
						}
						if (node3.Name == "ATK")
						{
							pokemonSO.stats.ATK = int.Parse(node3.InnerText);
						}
						if (node3.Name == "DEF")
						{
							pokemonSO.stats.DEF = int.Parse(node3.InnerText);
						}
						if (node3.Name == "SPD")
						{
							pokemonSO.stats.SPD = int.Parse(node3.InnerText);
						}
						if (node3.Name == "SAT")
						{
							pokemonSO.stats.SAT = int.Parse(node3.InnerText);
						}
						if (node3.Name == "SDF")
						{
							pokemonSO.stats.SDF = int.Parse(node3.InnerText);
						}
					}
				}
			}
			idNumber++;
			idDef = "";
			id = "00";
			id += idNumber.ToString();
            idDef = id.Substring(id.Length - 3);
            AssetDatabase.CreateAsset(pokemonSO, "Assets/Data/" + idDef + "_" + pokemonSO.pokemonName.ToLower() +".asset");
        }
    }

	[MenuItem("Pokedex/FixXML")]
	static void FixXML()
    {
		XmlDocument doc = new XmlDocument();
			doc.Load("Assets/XML/pokedex.xml");
        XmlNode firstChild = doc.ChildNodes[1];
        Debug.Log("d " + firstChild.Name);
		List<XmlNode> toRemove = new List<XmlNode>();
		foreach (XmlNode node in firstChild.ChildNodes)
		{
			toRemove.Clear();
			foreach (XmlNode node2 in node.ChildNodes)
			{
				Debug.Log(node2.Name);
				if (node2.Name == "height" || node2.Name == "weight")
				{
					toRemove.Add(node2);
				}

			}
			foreach(XmlNode nodeRemove in toRemove)
            {
				node.RemoveChild(nodeRemove);
            }
		}
		doc.Save("Assets/XML/pokedex_fixed.xml");
		AssetDatabase.Refresh();
	}

	[MenuItem("Pokedex/DeleteAllPokemon")]
	static void DeleteAllPokemon()
	{
		DirectoryInfo di = new DirectoryInfo("Assets/Data");

		foreach (FileInfo file in di.GetFiles())
		{
			file.Delete();
		}
		AssetDatabase.Refresh();
	}
}
