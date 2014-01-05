using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class ScriptObject : MonoBehaviour {

	GameObject ClickMenu;
	
	void Start ()
	{
		int CurrentMileStone = 3;
		string ViewPoint = "Garage";
		string ClickedObject = "Coliseum";
		string CommandChosen = "Move";
		
		string A = LoadText (Application.dataPath + "\\Resources\\XML\\Strings.xml");
		string B = SubStrA (A, "<MileStone0>", "</MileStone0>");
		string C = "<MileStone" + CurrentMileStone + ">";
		if (StrSea (A, C)) { C = SubStrA (A, "<MileStone" + CurrentMileStone + ">", "</MileStone" + CurrentMileStone + ">"); }
		else { C = ""; }
		if (C == "") { C = B; }
		C = SubStrA (C, "<" + ViewPoint + ">", "</" + ViewPoint + ">");
		C = SubStrA (C, "<" + ClickedObject + ">", "</" + ClickedObject + ">");
		C = SubStrA (C, "<" + CommandChosen + ">", "</" + CommandChosen + ">");
		Debug.Log (C);
		Debug.Log (GameObject.Find ("Main Camera").camera.orthographicSize);
	}
	
	/// <summary>
	/// Loads all text from a file into a <c>string</c>.
	/// </summary>
	/// <param name="FileToRead">The File you want to read.</param>
	/// <returns>A <c>string</c> containing all of the text in the given file.</returns>
	public string LoadText(string FileToRead)
	{
		string P = "";
		try
		{
			P = File.ReadAllText(FileToRead);
		}
		catch { }
		return P;
	}
	
	/// <summary>
	/// Gets all text found in a <c>string</c> before a specific character.
	/// </summary>
	/// <param name="FullString">The <c>string</c> you want to shorten.</param>
	/// <param name="AllTextBeforeThis">The <c>char</c> you want to get all text before it's appearance.</param>
	/// <param name="LastIndex">Set this to <c>true</c> to get all text before the last instance of the <c>char</c> in the string.</param>
	/// <returns>A <c>string</c> containing all text found before the chosen character.</returns>
	public string SubStrB(string FullString, string AllTextBeforeThis, bool LastIndex = false)
	{
		try
		{
			if (LastIndex == false)
			{
				FullString = FullString.Substring(0, FullString.IndexOf(AllTextBeforeThis));
			}
			else
			{
				FullString = FullString.Substring(0, FullString.LastIndexOf(AllTextBeforeThis));
			}
		}
		catch { }
		return FullString;
	}
	
	/// <summary>
	/// Gets all text found in a <c>string</c> after a specific character then before a specific character.
	/// </summary>
	/// <param name="FullString">The <c>string</c> you want to shorten.</param>
	/// <param name="AllTextAfterThis">The <c>char</c> you want to get all text after it's appearance.</param>
	/// <param name="AllTextBeforeThis">The <c>char</c> you want to get all text before it's appearance.</param>
	/// <returns>A <c>string</c> containing all text found between the chosen characters.</returns>
	public string SubStrA(string FullString, string AllTextAfterThis, string AllTextBeforeThis)
	{
		FullString = SubStrA(FullString, AllTextAfterThis);
		FullString = SubStrB(FullString, AllTextBeforeThis);
		return FullString;
	}
	
	/// <summary>
	/// Gets all text found in a <c>string</c> before a specific character then after a specific character.
	/// </summary>
	/// <param name="FullString">The <c>string</c> you want to shorten.</param>
	/// <param name="AllTextBeforeThis">The <c>char</c> you want to get all text after it's appearance.</param>
	/// <param name="AllTextAfterThis">The <c>char</c> you want to get all text before it's appearance.</param>
	/// <returns>A <c>string</c> containing all text found between the chosen characters.</returns>
	public string SubStrB(string FullString, string AllTextBeforeThis, string AllTextAfterThis)
	{
		FullString = SubStrB(FullString, AllTextBeforeThis);
		FullString = SubStrA(FullString, AllTextAfterThis);
		return FullString;
	}
	
	/// <summary>
	/// Gets all text found in a <c>string</c> after a specific character.
	/// </summary>
	/// <param name="FullString">The <c>string</c> you want to shorten.</param>
	/// <param name="AllTextBeforeThis">The <c>char</c> you want to get all text after it's appearance.</param>
	/// <param name="LastIndex">Set this to <c>true</c> to get all text after the last instance of the <c>char</c> in the string.</param>
	/// <returns>A <c>string</c> containing all text found after the chosen character.</returns>
	public string SubStrA(string FullString, string AllTextAfterThis, bool LastIndex = false)
	{
		try
		{
			if (LastIndex == false)
			{
				FullString = FullString.Substring(FullString.IndexOf(AllTextAfterThis) + AllTextAfterThis.Length);
			}
			else
			{
				FullString = FullString.Substring(FullString.LastIndexOf(AllTextAfterThis) + AllTextAfterThis.Length);
			}
		}
		catch { }
		return FullString;
	}
	
	/// <summary>
	/// Search a <c>string</c> for another <c>string</c>.
	/// </summary>
	/// <param name="TextToSearch">The <c>string</c> you want to search through.</param>
	/// <param name="TextToFind">The <c>string</c> you want to find.</param>
	/// <returns><c>true</c> if the given string was found.</returns>
	public bool StrSea(string TextToSearch, string TextToFind)
	{
		if (TextToSearch.IndexOf(TextToFind) >= 0) { return true; }
		else { return false; }
	}
}
