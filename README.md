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

