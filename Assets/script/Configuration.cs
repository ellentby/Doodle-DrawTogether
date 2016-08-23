using UnityEngine;
using System.Collections;
using NCMB;

public static class Configuration{
	public static Status status = Status.idle; 
	public static string username = "ellen";
	public static string theme = "";
	public static NCMBObject themeData;
}

public enum Status{newTheme, newDoodle,doodle,theme,idle};
