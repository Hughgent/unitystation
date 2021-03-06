﻿using System.Collections;

/// <summary>
///     Message that tells client to add a ChatEvent to their chat
/// </summary>
public class AnnouncementMessage : ServerMessage
{
	public static short MessageType = (short) MessageTypes.AnnouncementMessage;
	public string Text;

	public override IEnumerator Process() {
		yield return null;

		//Yeah, that will lead to n +-simultaneous tts synth requests, mary will probably struggle
		MaryTTS.Instance.Synthesize( Text, bytes => {
			Synth.Instance.PlayAnnouncement(bytes);
		} );
	}

	public static AnnouncementMessage SendToAll( string text ) {
		AnnouncementMessage msg = new AnnouncementMessage{ Text = text };

		msg.SendToAll();

		return msg;
	}
}