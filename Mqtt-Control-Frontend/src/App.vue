<template>
  <div>
    <div>selam Fatih</div>
    <div>
      <div>
        <Button @click="btnGetir('red')">Red</Button>
        <Button @click="btnGetir('green')">Green</Button>
        <Button @click="btnGetir('blue')">Blue</Button>
        <Button @click="btnGetir('white')">White</Button>
      </div>

      <div>
        <span>R</span>
        <input class="input" type="number" v-model="data.red" />
        <span>G</span>
        <input class="input" type="number" v-model="data.green" />
        <span>B</span>
        <input class="input" type="number" v-model="data.blue" />
        <span>W</span>
        <input class="input" type="number" v-model="data.white" />
      </div>

      <hr />

      <div>
        <span>Device ID:</span>
        <input type="text" v-model="data.deviceId" />
      </div>

      <hr />

      <div>
        <Button @click="dataGonder">Gonder</Button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      data: {
        red: 0,
        green: 0,
        blue: 0,
        white: 0,
        deviceId: 0,
      },
    };
  },

  mounted() {},

  methods: {
    btnGetir(data) {
      if (data === "red") {
        this.data.red = 255;
        this.data.green = 0;
        this.data.blue = 0;
        this.data.white = 0;
      } else if (data === "green") {
        this.data.red = 0;
        this.data.green = 255;
        this.data.blue = 0;
        this.data.white = 0;
      } else if (data === "blue") {
        this.data.red = 0;
        this.data.green = 0;
        this.data.blue = 255;
        this.data.white = 0;
      } else if (data === "white") {
        this.data.red = 255;
        this.data.green = 255;
        this.data.blue = 255;
        this.data.white = 255;
      }
    },

    dataGonder() {
      let deger = `{"clr":[${this.data.red},${this.data.green},${this.data.blue},${this.data.white}]}`;
      console.log('deger :>> ', deger, this.data.deviceId);
       axios.post("https://localhost:7205/api/MqttSender", {
         mac_address: this.data.deviceId,
         message: deger,
       });
    },
  },
};
</script>

<style scoped>
.input {
  width: 50px;
  margin: 10px;
}
</style>
