# Unity World Interaction System – Case Study

Bu proje, Ludu Arts Unity Developer Intern teknik case’i kapsamında geliştirilmiş,
raycast tabanlı modüler bir **World Interaction System** prototipidir.

Oyuncu dünyadaki nesnelerle etkileşime girebilir (anahtar toplama, kapı açma, switch kullanma, sandık açma vb.).
Sistem; interface tabanlı mimari, interaction type ayrımı ve basit inventory yapısı üzerine kurulmuştur.

---

## Unity Version

- Unity 6000.0.40f1

---

## Kurulum

1. Projeyi klonlayın veya zip olarak indirin.
2. Unity Hub üzerinden projeyi açın.
3. `Assets/_Project/Scenes/Main.unity` sahnesini açın.
4. Play butonuna basın.

---

## Kontroller

- WASD → Hareket
- Mouse → Kamera
- E → Etkileşim

---

## Sistem Özeti

### Interaction System

- Kamera merkezinden raycast ile hedef algılama
- `IInteractable` interface’i üzerinden tüm etkileşimler
- Tek aktif hedef
- Dinamik prompt UI
- Hold interaction için progress bar

### Interaction Types

- Instant  
  (Key pickup)

- Toggle  
  (Door, Switch)

- Hold  
  (Chest)

---

## Implemented Interactables

### KeyPickup
- Instant interaction
- ScriptableObject tabanlı item sistemi
- Inventory’ye eklenir

### Door
- Toggle interaction
- Locked / Unlocked state
- Required key kontrolü
- Aç / kapa

### Switch
- Toggle interaction
- UnityEvent üzerinden başka objeleri tetikler (Door)

### Chest
- Hold interaction (basılı tutma)
- Sadece bir kere açılır
- İçinden item verir

---

## Inventory

- Player üzerinde çalışan basit inventory sistemi
- ItemData ScriptableObject ile tanımlı
- UI’da toplanan item’lar listelenir

---

## Proje Yapısı

Assets/_Project
├ Scenes
├ Scripts
│ ├ Core
│ │ ├ Interaction
│ │ ├ Inventory
│ │ └ Player
│ ├ Gameplay
│ │ └ Interactables
│ └ UI
├ ScriptableObjects
└ Docs


---

## Design Decisions

- Raycast based interaction tercih edildi (trigger yerine)
- Interface tabanlı yapı kullanıldı (`IInteractable`)
- InteractionType enum ile davranış ayrımı yapıldı
- Inventory HashSet ile tutuldu (ID bazlı)
- Event driven switch-door bağlantısı

---

## Known Limitations / Trade-offs

- Kapı animasyonları instant (tween kullanılmadı)
- Görsel polish minimum seviyede tutuldu
- Inventory UI her frame refresh ediliyor (basitlik adına)

---

## Time Distribution (yaklaşık)

- Core movement + camera: ~30 dk
- Interaction system: ~2 saat
- Inventory + keys: ~1 saat
- Door / Switch / Chest: ~2 saat
- UI + debugging + cleanup: ~1 saat
- Docs + test: ~30 dk

---

## LLM Usage

LLM (ChatGPT) mimari planlama ve bazı sistem taslakları için kullanılmıştır.  
Detaylı kayıtlar `PROMPTS.md` dosyasında yer almaktadır.
