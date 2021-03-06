using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor (typeof(OSGrenade))]
public class OSGrenadeInspector : Editor {
	public override void OnInspectorGUI () {
		OSGrenade grenade = (OSGrenade) target;

		if ( !grenade.item ) {
			grenade.item = grenade.GetComponent< OSItem > ();

			GUI.color = Color.red;
			EditorGUILayout.LabelField ( "There is no OSItem component on this object!", EditorStyles.boldLabel );
			GUI.color = Color.white;
			return;
		}

		DrawDefaultInspector ();

		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ( "Attributes", EditorStyles.boldLabel );

		grenade.damageIndex = EditorGUILayout.Popup ( "Damage", grenade.damageIndex, grenade.item.GetAttributeStrings () );
		grenade.firingRateIndex = EditorGUILayout.Popup ( "Throwing rate", grenade.firingRateIndex, grenade.item.GetAttributeStrings () );
		grenade.rangeIndex = EditorGUILayout.Popup ( "Throwing range", grenade.rangeIndex, grenade.item.GetAttributeStrings () );

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ( "Sounds", EditorStyles.boldLabel );

		grenade.equippingSoundIndex = EditorGUILayout.Popup ( "Equip", grenade.equippingSoundIndex, grenade.item.GetSoundStrings () );
		grenade.explodingSoundIndex = EditorGUILayout.Popup ( "Explode", grenade.explodingSoundIndex, grenade.item.GetSoundStrings () );
		grenade.holsteringSoundIndex = EditorGUILayout.Popup ( "Holster", grenade.holsteringSoundIndex, grenade.item.GetSoundStrings () );
		grenade.throwingSoundIndex = EditorGUILayout.Popup ( "Throw", grenade.throwingSoundIndex, grenade.item.GetSoundStrings () );
	}
}
