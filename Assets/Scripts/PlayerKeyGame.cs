using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeyGame : MonoBehaviour
{

    [SerializeField] GameObject _duvar, _kapi, _butonlar, _mainCamera;
    [SerializeField] Text _kapiText, _kirmiziText, _maviText, _duvarText;

    int[] _anahtarlar = new int[3];

    private void OnCollisionEnter2D(Collision2D collision)
    {

        _butonlar.SetActive(false);

        if (collision.gameObject.tag == "kapi")
        {
            Destroy(_duvar);
        

            if (_anahtarlar[2] == 2)
            {
                _butonlar.SetActive(true);
            }

            else if (_anahtarlar[1] == 1)
            {
                _kapiText.text = "Yanlýþ Anahtar";
            }

            else if (_anahtarlar[0] == 0)
            {
                _kapiText.text = "Anahtar lazým. Lütfen onu bul.";
            }

        }

        if (collision.gameObject.tag == "duvar")
        {
            _duvarText.text = "Önce kapýya gitmelisin.";
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kapi")
        {
            _kapiText.text = "";
        }

        if (collision.gameObject.tag == "duvar")
        {
            _duvarText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KirmiziAnahtar")
        {
            _anahtarlar[1] = 1;
            _kirmiziText.text = "Kýrmýzý anahtar alýndý.";
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MaviAnahtar")
        {
            _anahtarlar[2] = 2;
            _maviText.text = "Mavi anahtar alýndý.";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(_kirmiziText);
        _maviText.text = "";
    }

    public void kirmiziButonSecimi()
    {
        _butonlar.SetActive(false);
        _kapiText.text = "Hatalý seçim";
        _mainCamera.GetComponent<Camera>().backgroundColor = Color.red;


    }

    public void maviButonSecimi()
    {
        _butonlar.SetActive(false);
        _kapi.transform.position += new Vector3(0, 15f);
        _mainCamera.GetComponent<Camera>().backgroundColor = Color.green;
    }



}
