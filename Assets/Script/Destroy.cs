using UnityEngine;
using System.Collections.Generic;

public class DeleteObject : MonoBehaviour
{
    public Color targetColor = Color.red;

    // ���ݏd�Ȃ��Ă���I�u�W�F�N�g���L�^
    private List<GameObject> overlapping = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!overlapping.Contains(collision.gameObject))
        {
            overlapping.Add(collision.gameObject);
        }

        // �^�O�ň�v���Ă�����̂��J�E���g
        List<GameObject> sameTag = overlapping.FindAll(obj => obj.tag == this.tag);

        if (sameTag.Count == 2)
        {

            foreach (GameObject obj in sameTag)
            {
                Destroy(obj);
            }
            Destroy(this.gameObject); // �������g������
        }

        // �F����v���Ă�����̂��J�E���g
        SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            List<GameObject> sameColor = overlapping.FindAll(obj =>
            {
                SpriteRenderer s = obj.GetComponent<SpriteRenderer>();
                return s != null && s.color == targetColor;
            });

            if (sameColor.Count == 2)
            {

                foreach (GameObject obj in sameColor)
                {
                    Destroy(obj);
                }
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlapping.Remove(collision.gameObject);
    }
}
