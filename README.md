# spotifyFollowerAccounting

Spotify takipçi sayısını izlemek, arşivlemek ve raporlamak için **hızlı başlangıç** aracı.  
Belirli sanatçı veya kullanıcı ID’leri için takipçi sayısını periyodik olarak çeker, zaman damgalı olarak kaydeder; CSV/JSON çıktılar ve basit rapor/grafikler üretir.

> **Not:** Bu README depo içeriği görülmeden oluşturulmuş şablondur. Dosya/komut adlarını kendi projenize göre güncelleyin.

---

## 🚀 Özellikler

- 🎯 Bir veya birden çok **artist/user ID** için takipçi sayısı çekme  
- 🕒 **Zaman damgalı** arşivleme (CSV/JSON)  
- 📈 **Trend ve fark** raporları (günlük/haftalık)  
- 📊 (Opsiyonel) Basit grafik çıktıları  
- ⏰ Cron / Görev Zamanlayıcı ile periyodik çalıştırma

---

## 🧰 Gereksinimler

- **Python 3.10+**
- Spotify API erişimi (Developer Dashboard)

Örnek `requirements.txt`:
```
spotipy>=2.24.0
pandas>=2.2.0
matplotlib>=3.8.0
python-dotenv>=1.0.1
```

Kurulum:
```bash
python -m venv .venv
# Windows
.venv\Scripts\activate
# macOS/Linux
source .venv/bin/activate

pip install -r requirements.txt
```

---

## 🔐 Spotify Uygulaması ve Ortam Değişkenleri

1. https://developer.spotify.com/dashboard üzerinden uygulama oluşturun.  
2. Redirect URI ekleyin (örnek): `http://localhost:8080/callback`  
3. Proje kökünde `.env` oluşturun:

```dotenv
SPOTIFY_CLIENT_ID=YOUR_CLIENT_ID
SPOTIFY_CLIENT_SECRET=YOUR_CLIENT_SECRET
SPOTIFY_REDIRECT_URI=http://localhost:8080/callback

# İzlenecek hedef ID'ler (artist veya user). Virgülle ayırın.
TARGET_IDS=1vCWHaC5f2uS3yhpwWbIA6,66CXWjxzNUsdJxJ2JdwvnR

# Çıktı yolu ve dosya adları
OUTPUT_DIR=./data
HISTORY_CSV=followers_history.csv
HISTORY_JSON=followers_history.json
```

---

## ▶️ Kullanım

> Aşağıdaki komutlar **örnek**tir; kendi proje yapınıza göre `main.py` veya `src/main.py` vb. uyarlayın.

- **İlk çalıştırma / OAuth akışı:**
  ```bash
  python main.py
  ```

- **Anlık veri çekimi:**
  ```bash
  python main.py fetch
  ```

- **7 günlük fark raporu:**
  ```bash
  python main.py report --window 7
  ```

- **Grafik üretimi (tek ID):**
  ```bash
  python main.py plot --id 66CXWjxzNUsdJxJ2JdwvnR
  ```

İlk yetkilendirmede tarayıcı açılabilir. Başarılı işlemden sonra veriler `data/` altında birikir.

---

## 📁 Örnek Proje Yapısı

```
spotifyFollowerAccounting/
├─ src/
│  ├─ auth.py          # OAuth, token yenileme
│  ├─ api.py           # Spotify API istekleri (takipçi sayısı vb.)
│  ├─ storage.py       # CSV/JSON okuma-yazma
│  ├─ report.py        # Trend/fark hesapları
│  ├─ plot.py          # Grafik üretimi (matplotlib)
│  └─ main.py          # CLI giriş noktası (argparse)
├─ data/
│  ├─ followers_history.csv
│  └─ followers_history.json
├─ .env
├─ requirements.txt
└─ README.md
```

---

## 📊 Çıktı Örnekleri

**CSV**
```csv
timestamp,id,type,name,followers
2025-08-14T12:00:00Z,66CXWjxzNUsdJxJ2JdwvnR,artist,Ariana Grande,95432123
2025-08-14T12:00:00Z,1vCWHaC5f2uS3yhpwWbIA6,artist,Avicii,28934567
```

**JSON**
```json
[
  {
    "timestamp": "2025-08-14T12:00:00Z",
    "id": "66CXWjxzNUsdJxJ2JdwvnR",
    "type": "artist",
    "name": "Ariana Grande",
    "followers": 95432123
  }
]
```

---

## ⏱️ Zamanlama (Opsiyonel)

**Cron** (her gün 12:00):
```cron
0 12 * * * /usr/bin/python3 /path/to/spotifyFollowerAccounting/main.py fetch >> /path/to/logs/cron.log 2>&1
```

**Windows Görev Zamanlayıcı** ile eşdeğer bir görev tanımlayabilirsiniz.

---

## 🧩 Sorun Giderme

- **invalid_client / redirect_uri_mismatch**  
  Dashboard’daki Redirect URI ile `.env` birebir aynı olmalı.
- **429 Rate Limit**  
  İstekleri seyrekleştirin; exponential backoff ekleyin.
- **Token süresi doluyor**  
  `refresh_token` akışını uyguladığınızdan emin olun.

---

## 🗺️ Yol Haritası

- [ ] Çoklu profil dosyası / hedef grupları  
- [ ] Otomatik e-posta/Telegram fark uyarısı  
- [ ] Dockerfile & docker-compose  
- [ ] Basit web dashboard (FastAPI + React)

---

## 🤝 Katkı

1. Fork → Branch (`feat/xyz`)  
2. Testleri çalıştırın  
3. Açıklayıcı bir PR gönderin

---

## 📝 Lisans

MIT (aksi belirtilmedikçe).

---

### ✍️ Not
Depo yapınızı paylaşırsanız README’yi **dosya adları ve gerçek komutlarla** birebir uyumlu hale getirebilirim.
