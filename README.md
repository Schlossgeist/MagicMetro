# MagicMetro
<img src="https://github.com/Schlossgeist/MagicMetro/blob/main/resources/demo.gif" width="75%"/>
A Plugin for MusicBee that automatically adjusts skins and theater views to your Windows desktop accent color or any 
color you like!

## Setup
1. Download the plugin from ![Releases](https://github.com/Schlossgeist/MagicMetro/releases) and install it like any other MusicBee plugin. If you use the non-portable 
   version of MusicBee, you now have to specify the path where you installed MusicBee so the plugin can find the skins 
   and theater views.
2. Navigate to the MusicBee plugin settings and verify that the plugin loaded correctly. You should see some colors
   based on the desktop accent color and a button that lets you choose a color yourself. This color is assignable via
   the *custom* attribute in the config file.
3. From here, open the config file and setup the file bindings:
   ```yaml
   custom-color: (128,128,255)                                   # your chosen color can be changed via the plugin settings
   xml-replace-jobs:                                             # for basic skins and theaterview files ending in .xml
     - path: Skins\Dark-Metro Series\DarkACCENT_extension.xml    # path to the file, relative to the MusicBee install directory
       replacements:
         L15C19: accent                                          # replace the color found at line 15 and column 19 with the desktop accent color
         L16C23: accent-dark1                                    # replace the color found at line 16 and column 23 with a darker shade of the desktop accent color
     - path: Plugins\TheaterMode.Embeded\Metrology - Fluent.xml
       replacements:
         L30C289: custom                                         # replace the color found at line 30 and column 289 with your chosen custom color
     - path: Plugins\TheaterMode.List\Metrology - Fluent.xml
       replacements:
         L30C289: accent-light3
   xmlc-replace-jobs:                                            # for bitmap skins ending in .xmlc
     - source-path: Skins\Dark-Metro Series\DarkVIOLET.xmlc      # path to the file, relative to the MusicBee install directory
       destination-path: Skins\Dark-Metro Series\DarkACCENT.xmlc # path to the recolored copy of the source file, relative to the MusicBee install directory
       replacements:
         1A35: { color: accent }                                 # extractID and image processing options: color, brightness, saturation
         D376: { source: D22F, color: accent, brightness: -10, saturation: 5 }
   ```
   <img src="https://github.com/Schlossgeist/MagicMetro/blob/main/resources/config_panel.png" width="50%"/>
4. The available color palette is displayed in the plugin settings. To find the correct line and column numbers,
   open the corresponding XML file with Windows Notepad and put your cursor in front of the color you want to replace.
   <img src="https://github.com/Schlossgeist/MagicMetro/blob/main/resources/line_and_column.png" width="50%"/>
   Note that other text editors may count the columns differently.
5. To find the extractIDs for XMLC replacements, press the Extract button in the plugin settings after you have defined
   the source path of the original skin file. In the config directory, there will now be a folder with all the images
   contained in the XMLC file. Choose the IDs of the files with the elements you want the plugin to recolor. Usually,
   you only want to replace the control elements which are already colored in the original skin and not their inactive,
   grayed-out variant. Assign a color from the palette.
6. Close MusicBee. The plugin only writes to the files after closing the application.
7. Open MusicBee and select the newly generated skin file. The interface should now be recolored according to your 
   settings.

## Tips
1. Most popular skins have a *flat* and a *bitmap* version. Use the **xml-replace-job** and the
   ```xml
   <root dependsOn="bitmap_generated.xmlc">
   ```
   tag in the *flat* version, link it to the *bitmap* version and use the **xmlc-replace-job** on the *bitmap* version. 
   This way, you can completely transform the MusicBee appearance. This trick will not be necessary after complete XMLC 
   color remapping has been implemented in a future release.
2. Although this plugin was specifically made for the DarkMetro skin series by [endeavour1934](https://getmusicbee.com/forum/index.php?action=profile;u=3985), most other skins 
   with a flat, untextured background should work too. If your favorite skin does not work, please let me know!
3. The plugin tries to recolor the images based on the most saturated pixel in the original image. If the recolored 
   version does not look quiet right, try to adjust the result with the brightness and saturation parameters, which 
   both range from -100% to +100%.
