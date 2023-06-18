using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionHandle : MonoBehaviour
{
     public AudioMixer mixer;
     public Slider musicSlider;
     public Slider sfxSlider;

     public Toggle vsync;
     public Toggle fullscreen;

    // Start is called before the first frame update
    void Start()
    {
        // Para guardar los niveles de audio entre niveles
        float initLevel = 0f;
        mixer.GetFloat("Music", out initLevel);
        musicSlider.value = initLevel;

        mixer.GetFloat("SFX", out initLevel);
        sfxSlider.value = initLevel;

		// Setea el vsync y el fullscreen al valor actual
		vsync.isOn = QualitySettings.vSyncCount != 0;
		fullscreen.isOn = Screen.fullScreen;
    }

    public void HandleMusic(float level)
    {
        mixer.SetFloat("Music", musicSlider.value);

		// Cuando el valor este al minimo resta - 40 para asegurarse de que la musica no se escuche
		if(musicSlider.value == musicSlider.minValue)
			musicSlider.value = musicSlider.minValue - 40;
    }

    public void HandleSFX(float level)
    {
        mixer.SetFloat("SFX", sfxSlider.value);

		// Cuando el valor este al minimo resta - 40 para asegurarse de que la musica no se escuche
		if(sfxSlider.value == sfxSlider.minValue)
			sfxSlider.value = sfxSlider.minValue - 40;
	}

	public void HandleVsync(bool value) {
		QualitySettings.vSyncCount = value ? 1 : 0;
	}

	public void HandleFullscreen(bool value) {
		Screen.fullScreen = value;
	}
}
