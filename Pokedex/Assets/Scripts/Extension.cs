using System;
using System.Collections.Generic;
using UnityEngine;

public static class Extension {
	public static string Capitalize(this string s) {
		string result = "";
		if (s != string.Empty) {
			string[] tokens = s.Split(' ');
			for (int i = 0; i < tokens.Length; i++) {
				tokens[i] = Char.ToUpper(tokens[i][0]) + tokens[i].Substring(1);
			}
			result = String.Join(" ", tokens);
		}
		return result;
	}
    public static void Alpha(this SpriteRenderer spriteRenderer, float a) {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a);
    }
}