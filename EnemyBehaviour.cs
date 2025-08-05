using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Seberapa cepat musuh ini akan berlari
    public float speed = 3f;
    // Untuk menyimpan data lokasi Jagoan (Player)
    private Transform playerTransform;
    // Berapa banyak kerusakan yang diberikan saat menabrak
    public int attackDamage = 10;

    // Fungsi ini berjalan saat musuh pertama kali muncul (di-spawn)
    void Start()
    {
        // Cari objek dengan tag "Player" di dalam game
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Jika ketemu...
        if (playerObject != null)
        {
            // ...simpan informasinya lokasinya
            playerTransform = playerObject.transform;
        }
        else
        {
            // Jika tidak ketemu, beri peringatan di konsol
            Debug.LogError("Objek dengan tag 'Player' tidak ditemukan! Musuh tidak tahu harus mengejar siapa.");
        }
    }

    // Fungsi ini berjalan terus-menerus setiap frame
    void Update()
    {
        // Jika kita tidak tahu lokasi Jagoan, jangan lakukan apa-apa
        if (playerTransform == null)
        {
            return;
        }

        // 1. Hitung arah dari musuh ke Jagoan
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        // 2. Gerakkan musuh ke arah tersebut
        transform.position += direction * speed * Time.deltaTime;
    }

    // Fungsi ini berjalan OTOMATIS saat musuh menabrak sesuatu
    void OnCollisionEnter(Collision collision)
    {
        // Cek, apakah yang ditabrak adalah Jagoan kita?
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ambil skrip HealthSystem dari Jagoan yang kita tabrak
            PlayerBehaviour playerHealth = collision.gameObject.GetComponent<PlayerBehaviour>();

            // Jika Jagoan punya skrip HealthSystem...
            if (playerHealth != null)
            {
                // ...beri kerusakan pada Jagoan!
                playerHealth.TakeDamage(attackDamage);
            }

            // Setelah menyerang, hancurkan diri sendiri! Misi selesai!
            Destroy(gameObject);
        }
    }
}
