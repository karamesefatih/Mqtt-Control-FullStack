<template>
  <div>
    <div>selam Fatih</div>
    <div>
      <span>{{ data }}</span>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import * as signalR from "@microsoft/signalr";
export default {
  data() {
    return {
      data,
      connection,
    };
  },

  mounted() {
    this.getData();
  },

  methods: {
    getData() {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

      connection.on("send", (data) => {
        console.log(data);
      });

      connection.start().then(() => connection.invoke("send", "Hello"));
    },
  },
};
</script>

<style scoped></style>
