param([string]$Exe="C:\Users\NB-67-06-01\TeamViewWake\TeamviewWake.exe")

$task = "Run_TeamviewWake_Interactive"

# ลบ task เดิมทิ้งก่อนเผื่อเคยมี
schtasks /delete /tn $task /f 2>$null

# สร้าง task ใหม่ (ตั้งเวลา = ตอนนี้ + 1 นาที)
$time = (Get-Date).AddMinutes(1).ToString("HH:mm")
schtasks /create /tn $task /tr "`"$Exe`"" /sc once /st $time /rl highest /it /f

# รันทันที
schtasks /run /tn $task

# รอให้ task สตาร์ทสักครู่
Start-Sleep -Seconds 5

# ลบทิ้งไม่ให้เหลือค้าง
schtasks /delete /tn $task /f
