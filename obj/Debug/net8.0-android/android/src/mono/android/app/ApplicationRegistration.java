package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("ZarzadzanieZadaniamiDnia.MainApplication, ZarzadzanieZadaniamiDnia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6457c2b3a0207d9f7d.MainApplication.class, crc6457c2b3a0207d9f7d.MainApplication.__md_methods);
		mono.android.Runtime.register ("Microsoft.Maui.MauiApplication, Microsoft.Maui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6488302ad6e9e4df1a.MauiApplication.class, crc6488302ad6e9e4df1a.MauiApplication.__md_methods);
		
	}
}
